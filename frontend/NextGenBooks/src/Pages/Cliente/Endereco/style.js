import styled from 'styled-components'

export const ContainerEndereco = styled.div`
    
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
export const ContainerBotao = styled.div`
    
    justify-content:flex-end;
    align-items:flex-end;
    display:flex;
    width:72%;
    .botao button{
        margin-top:10%;
        width:100%;
        background-color:#D26E4E;
        color:white;
        font-weight:bold;
}
      
      @media screen and (max-width: 600px)
    {
        & {
            padding: 0px 10vw 0px 10vw;
            flex-direction: column;
        }
     
    
    }

`