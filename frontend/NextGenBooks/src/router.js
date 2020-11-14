//Biblioteca
import React from 'react'
import { BrowserRouter, Switch, Route } from 'react-router-dom'

//Paginas:
import MostrarLivro from './Pages/MostrarLivro/index';
import HomePage from './Pages/Home/index.js';
import Login from './Pages/Login/index.js';
import Perfil from './Pages/Perfil/index.js';


//Funcionario 
import CadastrarFuncionario from "./Pages/Funcionario/CadastroFuncionario/CadastrarFuncionario/index.js"

//cliente
import EsqueciSenha from './Pages/Cliente/EsqueciSenha';
import TrocarSenha from './Pages/Cliente/EsqueciSenha/TrocarSenha/index.js';
import Cadastro from './Pages/Cliente/Cadastro/index';
import MinhasCompras from './Pages/Cliente/MinhasCompras/index.js';
import Favoritos from './Pages/Cliente/Favoritos/index'
import Carrinho from './Pages/Cliente/Carrinho/index';
import FinalizarCompra from './Pages/Cliente/FinalizarCompra';
import CadastrarEndereco from './Pages/Cliente/Endereco';
import AlterarCliente from './Pages/Cliente/AlterarCliente/index.js';
import VendaPorDia from './Pages/Relatorios/VendaPorDia/index.js';
import LivroVendaRelatorio from './Pages/Relatorios/VendaPorDia/LivrosDaCompra/index.js';
import VendaPorMes from './Pages/Relatorios/VendaPorMes/index.js';
import TopClientes from './Pages/Relatorios/TopClientes/index.js';
import MenuRelatorios from './Pages/Relatorios/index.js';
import TopVenda from './Pages/Relatorios/TopVendas/index.js';


export default function Rotas(){
    return(
      <BrowserRouter>
        <Switch>

          <Route path="/" exact={true} component={HomePage}/>
          <Route path="/Cadastro" component={Cadastro}/>
          <Route path="/Alterar-Dados" component = {AlterarCliente} />
          <Route path="/Acesso" component={Login} />
          <Route path="/EsqueciSenha" exact={true} component={EsqueciSenha}/>
          <Route path="/EsqueciSenha/TrocarSenha" component={TrocarSenha}/>

          <Route path="/Perfil" component={Perfil}/>
          
          <Route path="/Funcionario/Cadastro"  exact={true} component={CadastrarFuncionario}/>
          
          <Route path="/Endereco" component={CadastrarEndereco} />

          <Route path='/MostrarLivro' component={MostrarLivro} />
          <Route path="/Favoritos" component={Favoritos}/>
          <Route path="/Carrinho" component={Carrinho}/>

          <Route path="/MinhasCompras" component={MinhasCompras}/>
          <Route path="/FinalizarCompra" component={FinalizarCompra}/>

          <Route path="/VendaDia" component={VendaPorDia}/>
          <Route path="/LivroVenda" component={LivroVendaRelatorio}/>
          <Route path="/VendaMes" component={VendaPorMes}/>
          <Route path="/TopClientes" component={TopClientes}/>
          <Route path="/Relatorios" component={MenuRelatorios}/>
          <Route path="/TopVenda" component={TopVenda}/>

        </Switch>
      </BrowserRouter>
    )
}