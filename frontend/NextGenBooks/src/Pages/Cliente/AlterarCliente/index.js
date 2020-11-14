import React, { useState } from "react";
import { useHistory, Link } from "react-router-dom";

import Cookies from 'js-cookie';

import { toast, ToastContainer } from "react-toastify";

import Master from '../../Master/index.js';


import nextGenBookAPI from "../../../Service/NextGenBookApi";
import { CaixaImage, CaixaInformacoes, CadastroCaixa } from './style.js';

const api = new nextGenBookAPI();

export default function AlterarCliente(props) {

    let idcliente = Number(Cookies.get('id'));
    const navegacao = useHistory();
    const [foto, setFoto] = useState();
    const [nome, setNome] = useState(props.location.state.informacoes.nome);
    const [email, setEmail] = useState(props.location.state.informacoes.email);
    const [genero, setGenero] = useState(props.location.state.informacoes.genero);
    const [celular, setCelular] = useState(props.location.state.informacoes.celular);
    const [ file, setFile ] = useState();
    

    const AdicionarFoto = (arquivo) => {
        setFoto(arquivo);
        setFile(URL.createObjectURL(arquivo));
    }
    
    
    const salvarClick = async () => {
        try {
            let request = {
                email, 
                nome,
                celular,
                foto,
                genero
            }
            const response = await api.alterar(request, idcliente);
            toast.dark("Dados alterados com Sucesso," + response.data.Nome);
            navegacao.push("/Perfil");
        }
        catch(e) {
            toast.error(e.response.erro);
        }
    } 
    
    return(
        <Master>
            <h2>Alterar Dados da Conta</h2>
            <CadastroCaixa>
                <CaixaInformacoes>
                    <div className="form-group">
                        <label className="Nome">Nome completo:</label>
                        <input className="form-control" type="text" value={nome} onChange={(n) => setNome(n.target.value)} />
                    </div>
                    
                    <div className="form-group">
                        <label className="">E-mail:</label>
                        <input className="form-control" type="email" value={email} onChange={(n) => setEmail(n.target.value)}/>
                    </div>
                    
                    <div className="form-group">
                        <label>Gênero:</label>
                        <input className="form-control" value={genero} onChange={(x) => setGenero(x.target.value)} list="generos" name="genero" id="genero" />
                        <datalist id="generos">
                            <option value="Masculino"  />
                            <option value="Feminino" />
                            <option value="Outro" />
                        </datalist>
                    </div>
                    
                    <div className="form-group">
                        <label className="Celular">Celular:</label>
                        <input className="form-control" value={celular} type="text" onChange={(n) => setCelular(n.target.value)}/>
                    </div>
                </CaixaInformacoes>  

                <CaixaImage>
                    <label>
                        <span>Selecionar uma imagem de perfil</span>
                        <br />
                        <input type="file" id="img-input" name="image"
                            onChange={e => AdicionarFoto(e.target.files[0])}
                        />
                    </label>
                    
                    <div className="image-preview" id="img-container">
                        <img src={file} alt="" id="preview"></img>
                    </div>
                    <div className="button1">
                        <button type="button" className="btn btn-success" onClick={salvarClick} >Confirmar Alteração</button>
                    </div>
                </CaixaImage>              
            </CadastroCaixa>
            <ToastContainer />
        </Master>
    );
}