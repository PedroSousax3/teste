import React, { useState, useEffect, useRef } from 'react'

import { Link, useHistory } from "react-router-dom";
import { ToastContainer, toast, useToast } from "react-toastify"
import Cookies from 'js-cookie';


import { BuscarFoto } from '../../Service/fileApi.js'


import { PerfilComponest } from './style';
import { Container } from '../../components/Card/index.js'
import Master from '../Master/index.js';


import nextGenBookAPI from "../../Service/NextGenBookApi"
const api = new nextGenBookAPI();


export default function Perfil(props) {
    const navegacao = useHistory()
    const [infos, setInfos] = useState(props.location.state);
    const [informacoes, setInformacoes] = useState([]);

    const sairPerfil = () => {
        Cookies.remove('id');
        Cookies.remove('token');
        Cookies.remove('usuario');
        Cookies.remove('perfil');
        navegacao.push("/");
    }

    const consultarPerfil = async () => {
        let response = await api.mostrarPerfil(Number(Cookies.get('id')));
        setInformacoes(response);
    }

    useEffect(() => {
        consultarPerfil();

        console.log(informacoes);
    }, [])

    return (
        <Master>
            <PerfilComponest>
                <div>
                    <div>
                        <img src={BuscarFoto(informacoes.foto)} alt={`Foto de Perfil de ${informacoes.nome}`} style={{ margin: "auto", borderRadius: "100%", height: "150px", position: "relative", left: "50%", transform: "translateX(-50%)" }} />
                    </div>
                    <div className="informacoes">
                        <div style={{ marginTop: "10px" }}>NOME:{informacoes.nome} </div>
                        <div>DATA NASCIMENTO: {new Date(informacoes.nascimento).toLocaleDateString()} </div>
                        <div>GÊNERO: {informacoes.genero} </div>
                    </div>
                </div>

                <div className="botoes" style={{ marginTop: "10px", display: "flex", alignItems: "center", justifyContent: "center", flexDirection: "column" }}>
                    <Link to={{
                        pathname : "/Alterar-Dados",
                        state : {
                            informacoes
                        }
                    }}
                        className="btn btn-success"
                        style={{ marginTop: "5px" }}>
                        ALTERAR DADOS
                    </Link>
                    <Link to="/Endereco"
                        className="btn btn-success"
                        style={{ marginTop: "7px" }}>
                        CADASTRAR ENDEREÇO
                    </Link>
                    <button className="btn btn-success"
                        style={{ marginTop: "5px" }}
                        onClick={sairPerfil}>
                        SAIR
                    </button>
                </div>
            </PerfilComponest>
            <ToastContainer />
        </Master>
    );
}