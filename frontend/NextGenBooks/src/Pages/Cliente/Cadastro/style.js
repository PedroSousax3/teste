import styled from 'styled-components'

export const CadastroCaixa = styled.div`
        width: 100%;
        min-height: 100%;
        justify-content: space-around;
        flex-direction: row;
        display:flex;
        padding: 20px 30px;
        span{
                color:#00870D;
                font-weight: bold;
                font-size:20px;
        }

    @media screen and (max-width: 840px)
    {
        flex-direction: column;
    }
`

export const CaixaImage = styled.div`
    display: flex;
    flex-direction: column;
    height: auto;
    align-items: center;

    & > .button1 {
        margin: auto 0px 0px auto;
    }

    #preview {
        width: 200px;
        margin-bottom:20px;
    }
`

export const CaixaInformacoes = styled.div`
    min-width: 50%;
`
