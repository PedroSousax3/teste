import React, { useEffect, useState } from 'react';
import Cookies from 'js-cookie'
import { Link } from 'react-router-dom'
import logo from '../../Assets/images/logo/logo-pequena.png';
import { MenuStyled, ConteinerItensMenu } from './style.js';

export default function Menu(props){
    const [ perfil, setPerfil ] = useState(false);
    useEffect(
        () => setPerfil(Cookies.get('token') !== null && Cookies.get('token') !== undefined && Cookies.get("token") !== ""), []
    );
    return (
        <div>
            <MenuStyled> 
                <Link to = "/">
                    <img src={logo} alt = "Next Geen Books" className="LogoMenu"/> 
                </Link>

                <ConteinerItensMenu>
                    {
                        perfil  ?
                                    <li>
                                        <Link to = "/Favoritos" className="texto">Favoritos</Link>
                                        <Link to = "/Favoritos" className="fas fa-heart"></Link>
                                    </li>
                                :
                                    <>
                                    </>
                    }
                     {
                        perfil  ?
                                    <li>
                                        <Link to = "/Carrinho" className="texto">Carrinho</Link>
                                        <Link to = "/Carrinho" className="fas fa-shopping-cart"></Link>
                                    </li>
                                :
                                    <>
                                    </>
                    }
                     {
                        perfil  ?
                                    <li>
                                        <Link to = "/MinhasCompras" className="texto">Minhas Compras</Link>
                                        <Link to = "/MinhasCompras" className="far fa-handshake"></Link>
                                    </li>
                                :
                                    <>
                                    </>
                    }
                    <li>
                        {
                            perfil  ?
                                        <>
                                            <Link to = "/Perfil" className="texto">Meu Perfil</Link>
                                            <Link to = "/Perfil" className="far fa-user-circle"></Link>
                                        </>
                                    :
                                        <>
                                            <Link to = "/Acesso" className="texto">Acessar</Link>
                                            <Link to = "/Acesso" className="far fa-user-circle"></Link>
                                        </>
                        }
                    </li>
                </ConteinerItensMenu>
            </MenuStyled>
        </div>
    );
}