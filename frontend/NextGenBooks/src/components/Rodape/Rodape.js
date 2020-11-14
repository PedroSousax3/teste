import styled from 'styled-components';


export const Rodape = styled.footer`
  background-color:#98F0BB;
  width:100%;
  z-index: 100;
  position:absolute;
  padding-left: 16px;
  padding-right: 16px;
  padding-top: 32px;
  padding-bottom: 32px;
  color: var(--white);
  text-align: center;
  border-top:2px solid #00870D;
  @media (max-width: 800px) {
    margin-bottom: 50px;
  }
`;