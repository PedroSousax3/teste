import React, { useState, useEffect } from 'react';

//Master
import Master from '../Master/index';
import { Link } from 'react-router-dom';
import { toast, ToastContainer } from "react-toastify";

//Components:
import { BoxContainer } from '../../components/Card/styled.js';
import Cookies from 'js-cookie'

import { InserirCarrinhoApi } from '../../Service/carrinhoApi.js';
import { inserirFavoritoApi } from '../../Service/favoritosApi.js';
import { ConsultarPorIdLivro } from '../../Service/LivroApi.js';
import { BuscarFoto } from '../../Service/fileApi.js'
import { listarAvaliacaoLivroApi } from '../../Service/AvaliacaoLivro.js'

export default function MostrarLivro(props) {
    const [id] = useState(props.location.state.idlivro);
    const [nome, setNome] = useState("");
    const [idcliente] = useState(Number(Cookies.get('id')));
    const [valor, setValor] = useState();
    const [edicao, setEdicao] = useState();
    const [acabamento, setAcabamento] = useState("");
    const [altura, setAltura] = useState();
    const [peso, setpeso] = useState();
    const [largura, setLargura] = useState();
    const [lancamento, setLancamento] = useState();
    const [descricao, setDescricao] = useState("");
    const [paginas, setPaginas] = useState();
    const [editora, setEditora] = useState("");
    const [autor, setAutor] = useState([]);
    const [genero, setGenero] = useState("");
    const [qtd, setQtd] = useState(0);
    const [foto, setFoto] = useState("");
    const [avaliacoes, setAvaliacoes] = useState([]);


    function popularLivro(dados) {
        if (dados.livro != null && dados.livro != undefined) {
            setLancamento(new Date(dados.livro.lancamento).toLocaleDateString());
            setNome(dados.livro.nome);
            setValor(dados.livro.venda);
            setEdicao(dados.livro.edicao);
            setAcabamento(dados.livro.encapamento);
            setPaginas(dados.livro.paginas)
            setDescricao(dados.livro.descricao);
            setFoto(dados.livro.foto);
            if (dados.livro.editora != null && dados.livro.editora != undefined)
                setEditora(dados.livro.editora.nome);
            if (dados.livro.medida != null && dados.livro.editora != undefined) {
                setAltura(dados.livro.medida.altura)
                setLargura(dados.livro.medida.largura)
                setpeso(dados.livro.medida.peso)
            }
        }
        if (dados.estoque_livro != null && dados.estoque_livro !== undefined)
            setQtd(dados.estoque_livro.qtd);
        if (dados.generos != null && dados.generos !== undefined && dados.generos.length > 0)
            setGenero(dados.generos.map(x => x.genero + " ").toString());
        if (dados.autores != null && dados.autores !== undefined && dados.autores.length > 0)
            setAutor([...dados.autores]);
    }

    async function inserirCarrinho() {
        try {
            let request = {
                livro: id,
                cliente: idcliente,
                qtd: 1
            }
            await InserirCarrinhoApi(request);
            toast.success('Livro foi adicionado ao carrinho com sucesso');
        }
        catch (ex) {
            toast.error(ex.response.data.erro);
        }
    }

    async function inserirFavorito() {
        try {
            if (idcliente <= 0 || idcliente === undefined || idcliente == null || isNaN(idcliente)) {
                toast.error("Usúario não encotrado, nescessário a realização de login.");
            }
            else {
                await inserirFavoritoApi({
                    livro: id,
                    cliente: idcliente
                });
                toast.success(' 🥇 Livro foi adicionado a lista de favoritos com sucesso');
            }
        } catch (ex) {
            toast.info(' 🏁 ' + ex.response.data.erro);
        }
    }

    function MudarEstrela() {
        let botao = document.querySelector(".estrela");

        if (botao.classList) {
            botao.classList.remove("fas fa-star");
            botao.classList.add("far fa-star");
        } else {
            botao.classList.remove("far fa-star");
            botao.classList.add("fas fa-star");
        }
    }

    async function Consultar() {
        const response = await ConsultarPorIdLivro(id);
        popularLivro(response.data);

        const listAvaliacao = await listarAvaliacaoLivroApi(id);
        if (listAvaliacao != null && listAvaliacao !== undefined && listAvaliacao.length > 0)
            setAvaliacoes([...listAvaliacao]);
    }

    useEffect(() => {
        Consultar();
    }, [])

    return (
        <Master>
            <ToastContainer />
            
            <BoxContainer id="livro" theme={{ sc_border: "3.5px solid #00870D", sc_espace: "80px 80px", sc_padding: "10px", sc_direction: "column" }}>
            <Link to="/" >
                <button type="button" class="btn btn-info">
                    Voltar para menu
                </button>
            </Link>
                <BoxContainer id="titulo" theme={{ sc_espace: "10px 0px", sc_direction: "row" }}>
                    <h2>{nome}</h2>
                    {
                        idcliente <= 0 || idcliente === undefined || idcliente == null || isNaN(idcliente) ?
                            <></>
                            :
                            <i className="far fa-star estrela" onClick={inserirFavorito} style={{ cursor: "pointer" }} id="Icone"></i>
                    }
                </BoxContainer>
                <BoxContainer id="generico" theme={{ sc_espace: "10px 0px", sc_direction: "row" }}>
                    <BoxContainer id="imagem" theme={{ sc_espace: "10px 0px", sc_direction: "column" }}>
                        <img src={BuscarFoto(foto)} width="220px" alt="" />
                        <div>
                            <p>Quantidade Disponivel: {qtd}</p>
                        </div>
                    </BoxContainer>
                    <BoxContainer id="itemgenerico" theme={{ sc_width: "100%", sc_espace: "10px 0px", sc_direction: "column" }}>
                        <h5 style={{ marginTop: "15px", marginBottom: "5px" }}>Descrição do Livro</h5>
                        <div>
                            {descricao}
                        </div>
                    </BoxContainer>
                </BoxContainer>
                {
                    idcliente <= 0 || idcliente === undefined || idcliente == null || isNaN(idcliente) ?
                        <></>
                        :
                        <BoxContainer id="acoes" theme={{ sc_espace: "10px 0px" }}>
                            <button type="button" className="btn btn-carrinho" onClick={inserirCarrinho}>
                                Adicionar ao Carrinho
                                                                                                            </button>
                        </BoxContainer>
                }
                <BoxContainer id="descicao" theme={{ sc_espace: "10px 0px", sc_direction: "column" }}>

                    <div>
                        <div className="style-text-descr">Editora: {editora}</div>
                        <div className="style-text-descr">Autor: {autor.map(x => x.nome).toString()}</div>
                        <div className="style-text-descr">Gêneros: {genero}</div>
                    </div>
                    <div className="style-text-descr finalitem">Valor Unitário: {valor}</div>

                    <h5 style={{ marginTop: "15px", marginBottom: "5px" }}>Sobre o Escritor(a):</h5>
                    <div>
                        {autor.map(x =>
                            <div>
                                <h6>
                                    {x.nome}
                                </h6>
                                <div>
                                    {x.descricao}
                                </div>
                            </div>
                        )}
                    </div>
                </BoxContainer>
                <h5 style={{ marginTop: "15px", marginBottom: "5px" }}>Informações do Livro</h5>
                <BoxContainer id="informacoes" theme={{ sc_espace: "10px 0px" }}>
                    <ul>
                        <li>Número de páginas: {paginas}</li>
                        <li>Edição: {edicao}º</li>
                        <li>Tipo de Acabamento: {acabamento}</li>
                        <li>ISBN: 123456789</li>
                        <li>Data de Lançamento: {lancamento}</li>
                    </ul>
                    <ul>
                        <li>Altura: {altura}</li>
                        <li>Largura: {largura}</li>
                        <li>Peso: {peso}g</li>
                    </ul>
                </BoxContainer>

                <BoxContainer id="comentarios" theme={{ sc_direction: "column", sc_espace: "10px 0px" }}>
                    {
                        avaliacoes.map(x =>
                            <div className="coment">
                                <div style={{ display: "flex", width: "100%", justifyContent: "space-between" }}>
                                    <h6>Nome do usuario</h6>
                                    <p>{x.avaliacao}</p>
                                </div>
                                <p>
                                    {x.comentario}
                                </p>
                            </div>
                        )
                    }
                </BoxContainer>
            </BoxContainer>
        </Master>
    )
}