import styled from 'styled-components'

export const ContainerVendaDia = styled.div`
    
    flex:1;
    height:80vh;
    align-items:center;
    flex-direction:column;
    display:flex;
    margin-top:15px;
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

export const Containerinput = styled.div`
display:flex;
justify-content:space-around;
flex-direction:column;

`