import styled from  'styled-components'

export const Card = styled.div`
    width: 100%;
    height: auto;

    background-color : ${props => props.theme.bg_color};

    display: flex;
    flex-direction: column;

    border-radius: 5px;
    box-shadow: 0px 1px 1px rgba(0, 0, 0, 0.4);

    margin: 10px 0px;
`;

export const Title = styled.div`
    height: 35px;
    line-height: 35px;
    
    margin: auto 0px;
    padding: auto 15px;
    padding-left: 8px;

    border-bottom: .5px solid rgba(0, 0, 0, 0.4);
    font-size: 20px;
    font-weight: 600;
    color: ${props => props.theme.color};
    background-color: ${props => props.theme.bg_color};
`;

export const Container = styled.div`
    height: auto;
    max-width: 100%;
    
    padding-left: 10px;
    
    display: flex;

    align-items: center;

    & > .item {
        border-left: .5px solid rgba(0, 0, 0, 0.4);
        padding-left: 10px;
    }

    @media screen and (max-width: 650px)
    {
        & {
            padding-left: 0px;
        }

        & > .item {
            width: 100%;
            border-top: .5px solid rgba(0, 0, 0, 0.4);
            border-left: none;
            padding-left: 0px;
        }

        & {
            flex-direction: column;
            align-items: flex-start;
            justify-content: flex-start;
        }
    }

    @media screen and (max-width: 380px)
    {
        & > .item {
            padding-left: 5px;
        }
    }
`;

export const ImagemCard = styled.img`
    max-width: 180px;
    margin-right: 10px;

    @media screen and (max-width: 650px)
    {
        margin: auto;
    }

    @media screen and (max-width: 380px)
    {
        & {
            max-width: 100%;
            margin-right: 0px;
        }
    }
`;