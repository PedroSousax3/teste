import styled from 'styled-components';

export const MenuSpace = styled.div`
    margin-bottom: ${props => props.theme.sc_height};
    
    #menu-baixo{
        display: none;
    }
    @media screen and (max-width: 770px)
    {
        #menu-baixo{
            display: block
        }
    }
`; 