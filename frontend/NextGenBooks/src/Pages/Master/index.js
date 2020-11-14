import React from 'react';
import Menu from '../../components/Menu/index'
import { MasterPage, ContainerPage } from './style.js';

import { MenuSpace } from '../../components/Utils/index.js'
import { ToastContainer } from "react-toastify";

export default function Master(props) {
    return (
        <MasterPage>
            <ToastContainer />
            <MenuSpace theme={{sc_height : "60px"}}/>
            <Menu />
            
            <ContainerPage>
                {props.children}
            </ContainerPage>
            <MenuSpace id="menu-baixo" theme={{sc_height : "60px"}}/>
        </MasterPage>
    );
}