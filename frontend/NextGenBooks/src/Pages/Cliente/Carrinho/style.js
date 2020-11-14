import styled from 'styled-components'

export const CarrinhoStyled = styled.div``;

export const ConteinerItens = styled.div`
    min-height: calc(100vh - 296px);
    width: auto;
    
    padding: 10px;
    margin-right: 300px;

    display: flex;
    flex-direction: column;

    & > .card {
        width: 100%;
        margin-bottom: 15px;
    }

    & > .card > .card-header {
        font-weight: 600;
        font-size: 18px;
    }

    & > .card > .container {
        display: flex;
        padding: 10px 5px;
        background-color: var(--verde-claro);
    }

    & > .card > .container > .card-body{
        padding: 5px;
    }

    & > .card > .container > .img-thumbnail{
        float: left;
        height: 200px;
        width: 160px;
        margin-right: 10px;
    }

    .unidadebutao {
        display : flex;
    }

    & h6, & p {
        margin-bottom: 3px;
    }

    @media screen and (max-width: 770px)
    {
        margin-right: 0px;
    }

    @media screen and (max-width: 400px)
    {
        & > .card > .container > .img-thumbnail{
            width: 100%;
        }
    }
`;

export const Pesquisa = styled.div`

    position: fixed;
    right: 0px;
    bottom: 0px;

    height: calc(100vh - 60px);
    width: 300px;  
    background-color: var(--marrom-medio);

    padding: 5px;

    color: white;
    font-weight: 600;
    font-size: 18px;

    & > #btcompra
    {
        position: fixed;
        bottom: 10px;
        right: 10px;

        font-size: 18px;
        font-weight: 600;
    }

    @media screen and (max-width: 770px)
    {
        & {
            position: static;
            width: 100%;
            margin-bottom: 60px;
            height: auto;
        }

        & > .container {
            padding: 0px;
            margin: 0px;
        }

        & > .container > .form-group {
            margin: 5px;
        }

        & > #btcompra {
            position: static;
            width: 100%;
        }
    }
`;