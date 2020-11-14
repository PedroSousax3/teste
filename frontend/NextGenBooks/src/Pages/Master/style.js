import styled from 'styled-components';

export const MasterPage = styled.div`
    box-sizing: border-box;
    max-width: 100%;
    width: 100%;
    min-height: calc(100vh - 60px);

    @media screen and (max-width: 770px)
    {
        margin-bottom: 60px;
        min-height: calc(100vh - 120px);
    }
`;

export const ContainerPage = styled.div`
    @media screen and (max-width: 770px)
    {
        min-height: calc(100vh - 120px);
    }   
`;