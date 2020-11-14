import React, { useState, useEffect } from 'react'
import { Link } from 'react-router-dom'

import Master from '../Master/index';

import { Home, ContainerPesquisa, ContainerPreview, Card } from './style.js'

import { ListPostFile, BuscarFoto } from '../../Service/fileApi.js';

export default function HomePage(e) {
    const [consulta, setConsulta] = useState([]);
    const [nome, setNome] = useState("");    
    const [ qtdPost, setQtdPost ] = useState(0);

    const [inicio, setInicio] = useState(0);
    const [fim, setFim] = useState(10);

    const listarLivros = async () => {
        const result = await ListPostFile(inicio, fim, nome);
        console.log(result);
        setConsulta([...result.data.posteres]);
        setQtdPost(result.data.qtd);
        console.log(inicio, fim);
    }

    function listarPress (event) {
        if (event.key === 'Enter') {
            listarLivros();
        }
    }

    async function almentarPosicao() {
        if(qtdPost >= inicio) {
            setInicio(inicio + 10);
            setFim(fim + 10);
        }
        await listarLivros();
        console.log(inicio, fim);
    }

    async function diminuirPosicao() {
        if(inicio - 10 <= 0) {
            setInicio(0);
            setFim(10);
        }
        else {
            setFim(fim - 10);
            setInicio(inicio - 10);
        }
        await listarLivros();
        console.log(inicio, fim);
    }

    useEffect(() => {
        almentarPosicao();
    }, []);

    return (
        <Master>
            <Home>
                <ContainerPesquisa>
                    <div className="form-group" id="dvgenero" style={{ margin: "0px", width: "50vw" }}>
                        <input className="form-control" id="filtro" type="genero" onChange={(x) => setNome(x.target.value)} onKeyPress={listarPress} placeholder="Pequisar ..." />
                    </div>
                </ContainerPesquisa>

                <ContainerPreview style = {{justifyContent : "center"}}>
                    {
                        consulta.map(x =>
                            <Card className="card-livro" key={x.id} as={Link} to={{
                                pathname: "/MostrarLivro",
                                state: {
                                    idlivro: x.id
                                }
                            }}>
                                <div className="card-image" style={{ height: "300px", width: "170px" }}>
                                    <img src={BuscarFoto(x.nomeArquivo)} height="100%" width="100%" alt="" />
                                </div>
                                <div id="card-titulo">
                                    <h5 style={{ margin: "0px" }}>
                                        {x.nome}
                                    </h5>
                                </div>
                                <div className="card-focus">
                                </div>
                            </Card>
                        )
                    }
                </ContainerPreview>
                <nav aria-label="Navegação de página exemplo" style = {{ bottom: "0", position: "relative", marginTop : "35px", display: "flex", justifyContent : "center" }}>
                    <ul className="pagination">
                        <li className="page-item">
                            <button className="page-link"
                                    onClick={diminuirPosicao}>
                                Anterior
                            </button>
                        </li>
                        <li className="page-item">
                            <button className="page-link"
                                    onClick={almentarPosicao}>
                                Próximo
                            </button>
                        </li>
                    </ul>
                </nav>
            </Home>
        </Master>
    );
}