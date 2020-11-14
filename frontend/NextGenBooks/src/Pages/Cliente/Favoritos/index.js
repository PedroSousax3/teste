import React, { useState, useEffect } from "react";
import styled from 'styled-components'
import { Link } from "react-router-dom";
import { BuscarFoto } from '../../../Service/fileApi';
//Mastes
import Master from '../../Master/index.js';

import { toast, ToastContainer } from "react-toastify";


import { Card, Title, Container, ImagemCard } from '../../../components/Card/index.js'

//Api
import { listarApi, removerFav } from '../../../Service/favoritosApi.js'
import Cookies from 'js-cookie';

export default function EsqueciSenha() {

    const [registros, setRegistros] = useState([]);
    const [idCliente, setIdCliente] = useState(Number(Cookies.get('id')));

    const listarFavoritos = async () => {
        try {
            const response = await listarApi(idCliente);
            setRegistros([...response]);
            console.log(response);
        }
        catch (ex) {
            toast.error(ex.response.erro)
        }
    }

    const removerFavorito = async (id) => {
        try {
            await removerFav(id);

            toast.success("Livro removido dos Favoritos");
            
            await listarFavoritos();
        }
        catch (ex) {
            toast.error(ex.response.erro)
        }
    }

    useEffect(() => {
        listarFavoritos();
    }, []);

    return (
        <Master>
            <ToastContainer />
            <Favoritos>
                <h1>Lista de Favoritos</h1>
                {registros.map(x =>
                    <Card theme={{ bg_color: "#98F0BB" }}>
                        <Title theme={{ color: "black", bg_color: "rgba(0, 0, 0, 0.1)" }}>{x.nome}</Title>
                        <Container>
                            <div className="column item" ke={x.id}>
                                <div>
                                    <h5>
                                        Autor(a):
                                        </h5>
                                    <p>
                                        {x.atores}
                                    </p>
                                </div>
                                <div>
                                    <h5>
                                        Editora:
                                        </h5>
                                    <p>
                                        {x.editora}
                                    </p>
                                </div>
                                <div>
                                    <h5>
                                        Descrição:
                                        </h5>
                                    <p>
                                        {x.descricao}
                                    </p>
                                    <div>
                                    </div>
                                    <h5>
                                        Quantidade Disponível:
                                        </h5>
                                    <p>
                                        {x.qtd}
                                    </p>
                                </div>
                                <div>
                                    <Link to={{
                                        state: {
                                            idlivro: x.livro
                                        },
                                        pathname: "/MostrarLivro"
                                    }}>Ver detalhes</Link>

                                    <button className="btn btn-danger" onClick={() => removerFavorito(x.id)}>Remover Livro</button>
                                </div>
                            </div>
                        </Container>
                    </Card>
                )}
            </Favoritos>
        </Master>
    );
}

const Favoritos = styled.div`
    display: flex;
    flex-direction: column;

    padding: 10px 10%;

    & * {
        box-sizing: border-box;
    } 

    & p {
        word-break: break-word;
    } 

    @media screen and (max-width: 380px)
    {
        & {
            padding: 10px 5px;
        }
    }
`;