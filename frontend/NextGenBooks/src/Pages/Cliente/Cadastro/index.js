import React, { useState } from "react";
import { useHistory, Link } from "react-router-dom";

import Cookies from 'js-cookie';

import { toast, ToastContainer } from "react-toastify";

import Master from '../../Master/index.js';


//import {LoginCaixa} from "../../components/LoginCaixa/LoginCaixa";
import nextGenBookAPI from "../../../Service/NextGenBookApi";
import { CaixaImage, CaixaInformacoes, CadastroCaixa } from './style.js';

import UploadPhoto from '../../../components/UploadPhoto/UploadPhoto';

const api = new nextGenBookAPI();



export default function Cadastro(props) {

    const [acesso, setAcesso] = useState(props.location.state);

    const navegacao = useHistory();

    const [foto, setFoto] = useState();
    const [nome, setNome] = useState("");
    const [email, setEmail] = useState("");
    const [genero, setGenero] = useState('');
    const [usuario, setUsuario] = useState("");
    const [senha, setSenha] = useState("");
    const [confirmarsenha, setConfirmarSenha] = useState("");
    const [cpf, setCPF] = useState("");
    const [celular, setCelular] = useState("");
    const [nascimento, setNascimento] = useState(new Date().toLocaleDateString());
    const [file, setFile] = useState();


    const AdicionarFoto = (arquivo) => {
        setFoto(arquivo);
        setFile(URL.createObjectURL(arquivo));
    }


    const salvarClick = async () => {
        console.log(nascimento);
        try {
            let request = {
                usuario,
                email,
                senha,
                cpf,
                nome,
                celular,
                foto,
                genero,
                nascimento
            }
            const response = await api.cadastrar(request);
            toast.dark("Cadastro completo " + response.data.Nome);
            gerarCookies(response.data);
            navegacao.push("/Perfil", acesso);
        }
        catch (e) {
            toast.error("Por favor arrume os campos inválidos.");
        }
    }

    function gerarCookies(response) {
        Cookies.set('token', response.token, {
            expires: 1,
            path: '/'
        });
        Cookies.set('id', response.id, {
            expires: 1,
            path: '/'
        });
        Cookies.set('usuario', response.nome, {
            expires: 1,
            path: '/'
        });
        Cookies.set('perfil', response.perfil, {
            expires: 1,
            path: '/'
        });
    }

    return (
        <Master>
            
            <CadastroCaixa>
                <CaixaInformacoes>
                    <div className="form-group">
                        <label className="Nome">Nome completo:</label>
                        <input className="form-control" type="text" onChange={(n) => setNome(n.target.value)} />
                    </div>

                    <div className="form-group">
                        <label className="">E-mail:</label>
                        <input className="form-control" type="email" onChange={(n) => setEmail(n.target.value)} />
                    </div>

                    <div className="form-group">
                        <label>Gênero:</label>
                        <input className="form-control" onChange={(x) => setGenero(x.target.value)} list="generos" name="genero" id="genero" />
                        <datalist id="generos">
                            <option value="Masculino" />
                            <option value="Feminino" />
                            <option value="Outro" />
                        </datalist>
                    </div>

                    <div className="form-group">
                        <label className="Usuario">Usuário:</label>
                        <input className="form-control" type="text" onChange={(n) => setUsuario(n.target.value)} />
                    </div>

                    <div className="form-group">
                        <label className="Senha">Senha:</label>
                        <input className="form-control" type="password" onChange={(n) => setSenha(n.target.value)} />
                    </div>

                    <div className="form-group">
                        <label className="Confirmar-Senha">Confirmar Senha:</label>
                        <input className="form-control" type="password" onChange={(n) => setConfirmarSenha(n.target.value)} />
                    </div>

                    <div className="form-group">
                        <label className="CPF">CPF:</label>
                        <input className="form-control" type="text" onChange={(n) => setCPF(n.target.value)} maxLength="11" />
                    </div>

                    <div className="form-group">
                        <label className="Celular">Celular:</label>
                        <input className="form-control" type="text" onChange={(n) => setCelular(n.target.value)} data-mask="(00) 0000-0000" data-mask-selectonfocus="true"/>
                    </div>

                    <div className="form-group">
                        <label className="Celular">Data de Nascimento:</label>
                        <input className="form-control" type="date" value={nascimento} onChange={(n) => setNascimento(n.target.value)} />
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
                        <button type="button" className="btn btn-success" onClick={salvarClick} >Confirmar cadastro</button>
                    </div>
                </CaixaImage>
            </CadastroCaixa>
            <ToastContainer />
        </Master>
    );
}