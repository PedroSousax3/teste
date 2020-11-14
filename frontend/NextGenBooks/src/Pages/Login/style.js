import styled from 'styled-components'

export const ContainerLogin = styled.div`
    justify-content:center;
    flex:1;
    height:80vh;
    align-items:center;
    display:flex;
    justify-content:center;

    
    @media screen and (max-width: 600px)
    {
        & {
            padding: 0px 10vw 0px 10vw;
        }
    }

    @media screen and (max-width: 330px)
    {
        & {
            padding: 0px 5vw 0px 5vw;
        }
    }
`
