import styled from 'styled-components'

export const BoxContainer = styled.div`
    margin : ${props => props.theme.sc_espace};
    padding: ${props => props.theme.sc_padding};

    background-color: #98F0BB;
    border: ${props => props.theme.sc_border};
    border-radius: 3px;
    
    box-sizing: border-box;

    width: ${props => props.theme.sc_width};
    
    display: flex;
    flex-direction: ${props => props.theme.sc_direction};

    &#titulo {
        justify-content: space-between;
        position: sticky;
        top: 59px;
    }

        &#titulo > h2 {
            text-transform: uppercase;
            font-size: 26px;
            font-weight: 700;
            margin: 0;
            line-height: 30px;
        }

        &#titulo i.estrela {
            color: yellow;
            text-align: end;
            font-size: 30px;
            line-height: 30px;
        }

    .style-text-descr {
        font-size: 14px;
        font-weight: 500;
    }

    &#acoes {
        justify-content: space-between;
    }

        &#acoes > .btn {
            color: white;
            text-transform: uppercase;
            font-weight: 700;
        }
    
            #acoes > .btn-carrinho{
                background-color: #CACD28;
            }

            #acoes > .btn-comprar{
                background-color: #3859CE;
            }

    #itemgenerico {
        justify-content: center;
        padding-left: 5px;
    }

        &#generico > &#imagem > div > p {
            font-size: 11px;
            text-align: center;
            margin: 0;
        }

    &#informacoes {
        border: 1px solid black;
        padding: 4px;
    }
    
        &#informacoes > ul  {
            width: 100%;
            list-style-type: none;
            justify-content: space-between;
            margin: 0;
        }
        &#informacoes > ul:first-child  {
            padding: 0;
        }

    @media screen and (max-width: 775px)
    {
        &#livro {
            margin: 80px 15px;
        }
    }

    @media screen and (max-width: 775px)
    {
        &#livro {
            margin: 80px 15px;
        }

        &#generico {
            flex-direction: column;
        }

        #imagem {
            align-items: center;
        }
    }

    @media screen and (max-width: 650px)
    {
        &#informacoes {
            flex-direction: column;
        }

        &#informacoes > ul  {
            padding: 0;
        }
    }

    @media screen and (max-width: 450px)
    {
        &#acoes {
            flex-direction: column;
        }

        &#acoes > button  {
            width: 100%;
            margin: 5px 0px;
        }
    }

    @media screen and (max-width: 300px)
    {
        &#generico > #imagem > img {
            width: 100%;
        }
    }
`;