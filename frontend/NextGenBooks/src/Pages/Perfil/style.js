import styled from 'styled-components';

export const PerfilComponest = styled.div` 
    padding : 20px;
    display: flex;
    align-items: center;
    justify-content : space-between;

    @media screen and (max-width : 760px) {
        flex-direction: column;
    }

    @media screen and (max-width : 330px) {
        & > .botoes > *, & > * {
            width : 100%
        }
    }
`;

export const CaixaPerfil = styled.div`

background-color: rgb(152, 240, 187);
width: 90%;
height: 70vh;
display: flex;
flex-direction: column;

margin-top:2%;
border-radius:10px;
box-shadow:10px 10px 5px 0px rgb(0,0,0,0.2);
text-align:left;
font-weight:bold;
font-size:1rem;


input{
    border-radius:5px;
}

button{
    border-radius:10px;
    margin-left:10px;
    color:black;
}
`;