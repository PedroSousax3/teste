import styled from 'styled-components';

export const TelaContainer = styled.div`
    display:flex;
    flex-direction:collumn;
    justify-content:center;
    align-items:center;
    height:60vh;
    position:absolute;
`;

export const TelaFixa = styled.div` 
    display:flex;
    flex-direction:collumn;
    justify-content:center;
    align-items:center;
    position: fixed;
    height: 100vh;
    width: 100vw;
    z-index: 12000;
    left: 0;
    top: 0;
    background: rgba(0,0,0, 0.2);
   
`;