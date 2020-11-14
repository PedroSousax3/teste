import styled from 'styled-components';

export const MenuStyled = styled.div`   
    width: 100%;
    height: 60px;
    z-index: 1000;
    display: flex;
    justify-content: space-between;
    align-items: center;
    
    position: fixed;
    top: 0;
    left: 0;
    right: 0;

    padding: 0px 20px;
    border-bottom: 3px solid #00870D;
    background-color: #98F0BB;

    & > nav {
        width: 100%;
        background-color: #98F0BB;
    }
    @media screen and (max-width: 770px)
    {
        & {
            justify-content: center;
        }
    }
`;

export const ConteinerItensMenu = styled.ul`
    display: flex;
    padding: 0px;
    margin: 0px;

    & > li > a.fas, & > li > a.far {
        display: none;
    }

    & > li > a {
        padding: 10px 15px;
        text-decoration: none;
        border-radius: 4px;
        font-size: 18px;
        font-weight: 600;
        color: #00870D;

        :hover {
            background-color: #00870D;
            color: white;
        }
    }

    & > li {
        list-style-type: none;
        margin: 3px 6px;
    }

    .menu-item {
        display: block;
    }

    .menu-item:hover a > .menu-drop {
        position: absolute;
    }

    .menu-item > a > .menu-drop {
        display: none;
        position: relative;
    }
    @media screen and (max-width: 770px)
    {
        & {
            display: flex;
            justify-content: space-around;
            align-items: center;
            
            position: fixed;
            bottom: 0;
            left: 0;
            
            height: 60px;
            width: 100vw;
            border-top: 3px solid #00870D;
            background-color: #98F0BB;

            z-index: 100;

            .texto {
                display: none;
            }
        }

        & > li {
            margin: 0;
        }

        & > li > a.fas, & > li > a.far {
            display: block;
            font-size: 30px;
            color: #00870D;

            :hover {
                color: white;
            }
        }
    }
`;