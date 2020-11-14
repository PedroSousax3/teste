import styled from 'styled-components'

export const Home = styled.div` 
`;

export const ContainerPesquisa = styled.div`
    background-color: rgb(210, 110, 78);
    width: 100vw;
    display: flex;
    align-items: center;
    justify-content: center;
    z-index: 250;
    position: fixed;
    padding: 5px 25px;
`;

export const ContainerPreview = styled.div` 
    display: flex;
    flex-direction: row;
    flex-wrap: wrap;
        
    padding: 60px 10px 10px;
    flex-grow: 1;

    max-width: 100vw;

    & > * {
        padding: 5px;
    }
`;

export const Card = styled.div`
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;

    position: relative;
    width: 240px;

    height: auto;
    margin: 5px;

    border-radius: 3px;
    border: 1px solid rgba(0, 0, 0, 0.2);
    box-shadow: 1px 1px 3px rgba(0, 0, 0, 0.2);
    background-color: white;
    cursor: pointer;

    outline: none;
    text-decoration: none;

    transition: .4s linear;

    & *:hover {
        outline: none;
    }

    & > .card-titulo {
        flex-wrap: wrap;
        text-align: center;
    }

    .card-image {
        margin-bottom: auto;
    }

    .card-focus {
        transition: linear 0.2s;
        background-color: black;
        position: absolute;
        width: 100%;
        height: 100%;
        opacity: 0;
        top: 0;
    }

    .card-focus:hover {
        opacity: 0.4;
    }
`; 