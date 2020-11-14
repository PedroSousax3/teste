import React,{useState} from "react";
import {TelaContainer} from "./style.js";
import { useHistory, Link } from "react-router-dom";
import { toast, ToastContainer } from "react-toastify";
import nextgenBooks from "../../../../../../Service/NextGenBookApi";
import {TelaFixa} from "./style";

let api = new nextgenBooks();

export default function CancelarCompraConfirmar(props){
   const [condicao,setCondicao] = useState(props.condicao);
   const [idVendaStatus,setIdVendaStatus] = useState(props.IdVendaStatus);
    
   const CancelarSim = async () =>{ 
    try{
        await api.CancelarCompra(idVendaStatus);
        toast.success("O cancelamento da compra foi solicitado.");
    }catch(e) {
            toast.error(e.response.data.erro);
        }
    }
    const CancelarNao = () =>{
        setCondicao(false);
    }
    return(
        <div>
        {condicao === true &&
            <TelaFixa>
                  <div className="container" style={{backgroundColor:"white",minWidth:"25%",minHeight:"25%",borderRadius:"30px",textAlign:"center"}}>
                  <span>Cancelar Compra</span>
                  <p>Tem certeza que quer Cancelar a Compra?</p>
                  <div 
                  style={{
                          width:"80%",
                          justifyContent:"space-around",
                          display:"flex"
                      }}>
                      <button type="button" className="btn btn-primary" onClick={CancelarSim}>Sim</button>
                      <button type="button" className="btn btn-danger" onClick={CancelarNao}>Não</button>
                  </div>
             </div>
             </TelaFixa>
            
            }
            </div>
    )
}