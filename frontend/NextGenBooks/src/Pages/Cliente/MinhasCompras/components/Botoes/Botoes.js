import React,{useState} from "react";
import {BotaoContainer} from "./style.js";
import { useHistory, Link } from "react-router-dom";
import CancelarCompraConfirmar from "./CancelarCompraConfirmar";
import DevolverCompra from "./DevolverCompra";

export default function Botoes(props){

    const [condicao,setCondicao] = useState("");
    const [condicaoCancelar,setCondicaoCancelar] = useState(true);
    const [condicaodevolver,setCondicaoDevolver] = useState(true);
    const [idVendaLivro,setIdVendaLivro] = useState(props.IdVendaLivro);
    const [idVendaStatus,setidVendaStatus] = useState(props.IdVendaStatus);
    const [valor,setValor] = useState(props.valor);



    const MudarCancelar = () => {
        setCondicao("Cancelar");
    }

    const MudarDevolucao = () => {
        setCondicao("Devolucao");
    }

    return(
          <BotaoContainer>
            {condicao === "Cancelar" &&
               <CancelarCompraConfirmar
                 condicao = {true}
                 IdVendaStatus = {idVendaStatus}
               />
            }
              {condicao === "Devolucao" &&
                <DevolverCompra
                 condicao = {true}
                 IdDevolucao = {idVendaLivro}
                 valor = {valor}
                />
              }
            <div className="btn-group" role="group" aria-label="Exemplo básico">
              <button type="button" className="btn btn-primary"><Link to="/">Ver Detalhes</Link></button>
              <button type="button" className="btn btn-danger" onClick={MudarCancelar}>Cancelar Compra</button>
              <button type="button" className="btn btn-warning" onClick={MudarDevolucao}>Pedir Devolução</button>
              </div>
          </BotaoContainer>
    )
}