import React, { useState, useEffect } from "react";
import { Link, useHistory } from "react-router-dom";

import { css } from "@emotion/core";
import ClipLoader from "react-spinners/ClipLoader";

//Style
import { Pesquisa, ConteinerItens } from './style.js';
import { toast, ToastContainer } from "react-toastify";

//Components
import Master from '../../Master/index.js';

//Api 
import { ListarCarrinho, Remover, alterarQuantidadeApi } from '../../../Service/carrinhoApi.js';
import { BuscarFoto } from '../../../Service/fileApi.js';

import Cookies from 'js-cookie'

const override = css`
  display: block;
  margin: 0 auto;
  margin: auto 5px;
`;


export default function Carrinho(props) {
    const navegacao = useHistory()
    const [id, setId] = useState(Number(Cookies.get('id')));
    const [registros, setRegistros] = useState([]);
    const [valorlivros, setValorLivros] = useState(0);
    const [valorfrete, setValorFrete] = useState(0);
    const [totalcompra, setTotalCompra] = useState(0);
    const [estado, setEstado] = useState(false);
    const RemoverItem = async (id) => {
        await Remover(id);
        await ConsultarCarrinho(id);
    }


    function SomarCarrinho(result) {
        let calc = 0;
        let contador = 0;
        result.forEach(x => {
            let valor = valorlivros;
            let result = valor + (x.informacoes.venda * x.qtd);
            calc += result;
            contador++;
        });
        setValorLivros(calc);
        setTotalCompra(calc + contador);
        setValorFrete(contador);
    }

    const ConsultarCarrinho = async () => {
        const result = await ListarCarrinho(id);
        setRegistros([...result]);
        SomarCarrinho(result);
    }
    const Comprar = () => {
        navegacao.push("/FinalizarCompra", registros);
    }
    const alterarCarrinho = async (item, idcarrinho, qtd) => {
        try {
            setEstado(true);
            let response = await alterarQuantidadeApi(idcarrinho, qtd);
            ConsultarCarrinho();
            setEstado(false);
        }
        catch (ex) {
            toast.error(ex.response.erro)
        }
    }

    useEffect(() => {
        ConsultarCarrinho();
    }, []);

    return (
        <Master>
            <ToastContainer />
            <ConteinerItens>
                {registros.map((x) =>
                    <div className="card">
                        <div className="card-header" Key={x.id}>
                            {x.informacoes.nome}
                        </div>
                        <div className="container" Key={x.id}>
                            <img style={{ height: "300px", width: "180px" }} src={BuscarFoto(x.informacoes.foto)} alt="..." />
                            <div className="card-body" Key={x.id}>
                                <h6 className="card-title">Resumo</h6>
                                <p className="card-text">{x.informacoes.descricao}</p>
                                <h6 className="card-title">Editora</h6>
                                <p className="card-text">{x.informacoes.editora.nome}</p>
                                <h6 className="card-title">Data de Lancamento</h6>
                                <p className="card-text">{new Date(x.informacoes.lancamento).toLocaleDateString()}</p>
                            </div>
                        </div>
                        <div className="card-header" style={{ display: "flex", justifyContent: "space-between" }} Key={x.id}>
                            <button className="btn btn-danger" onClick={() => RemoverItem(x.id)}>Remover</button>
                            <div className="unidadebutao">
                                <input type="number" className="form-control" min="1" minLength="1" onChange={(qtd) => alterarCarrinho(x.qtd, x.id, Number(qtd.target.value))} value={x.qtd} style={{ width: "70px" }} />
                                <ClipLoader
                                    css={override}
                                    size={35}
                                    color={"#438719"}
                                    loading={estado}
                                />
                            </div>
                        </div>
                    </div>
                )}
            </ConteinerItens>
            <Pesquisa>
                <div className="container">
                    <div className="form-group">
                        <label>Valor total dos livros: </label>
                        <span> {valorlivros.toFixed(2)}</span>
                    </div>
                    <div className="form-group">
                        <label>Valor do frete: </label>
                        <span> {valorfrete} </span>
                    </div>
                    <div className="form-group">
                        <label>Total da compra: </label>
                        <span> {totalcompra.toFixed(2)} </span>
                    </div>
                </div>

                <button id="btcompra" type="button" className="btn btn-success" onClick={Comprar}>COMPRAR</button>
            </Pesquisa>
        </Master>
    );
}