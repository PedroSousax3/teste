import React, { useState } from "react";
import { useHistory, Link } from "react-router-dom";


import { CaixaEsqueciSenha } from './style';
import Master from "../../Master";
import { ToastContainer, toast } from "react-toastify";
import nextGenBookAPI from '../../../Service/NextGenBookApi'



const api = new nextGenBookAPI();

export default function EsqueciSenha(){
    const navegacao = useHistory();
    const [Email, setEmail] = useState("");
    const [Codigo, setCodigo] = useState("");
    const [id,setId] = useState();

    const verificarEmail = () => {
        if( Email==="" 
            || 
            Email.indexOf('@')===-1 
            || 
            Email.indexOf('.')===-1 
        ) return false;
        else return true;
    }

    const enviarEmailRecuperacao = async () => {
        let valido = verificarEmail();
        try {
            if(valido)
            {
                let request = {
                    Email
                }
                const response = await api.enviarEmail(request);
                toast.dark("Email enviado");
                setId(response.data.idLogin)
            }
            else
                toast.error("Campo e-mail não foi preenchido corretamente.");
        } 
        catch (ex) 
        {
            toast.error(ex.response.data.erro);
        }
    }

  const validarCodigo = async() => {
    try{
        let request = {
            Codigo
        }
        
        const response = await api.confirmarCodigo(request,id);
        navegacao.push("/EsqueciSenha/TrocarSenha",response.data);
    }catch(e){
        toast.error("Código inválido");
    }
  }

    return(
       <div>
           <Master children={
               <div>
                   <div style={{justifyContent:"center",alignItems:"center",paddingTop:"3%",display:"flex",flexDirection:"column"}}>
                        <div style={{width:"80%",display:"flex",justifyContent:"flex-start",fontSize:"25px",fontWeight:"bold"}}>
                                </div>
                        <CaixaEsqueciSenha>
                                    <div className="inputs form-row" >
                                        <input type="email" className="form-control col-7" id="email" placeholder="INFORME SEU E-MAIL"
                                        onChange = {(e) => setEmail(e.target.value)}  />
                                        <button type="button" clasName="btn btn-light col" 
                                        style={{cursor:"pointer"}}
                                            onClick={enviarEmailRecuperacao}
                                        >Enviar Código</button>
                                    </div>

                                    <div className="form-group row" style={{marginTop:"2%",width:"61%",marginLeft:"8%"}}>
                                        <div className="col-sm-10">
                                        <input type="text" className="form-control" id="codigo" placeholder="CÓDIGO"
                                        onChange = {(e) => setCodigo(e.target.value)}/>
                                        </div>
                                    </div>
                                    <div className="botao" style={{alignItems:"center", display:"flex", justifyContent:"center",width:"61%"}}>
                                        <button type="button" style={{width:"77%"}}className="btn btn-success" onClick={validarCodigo}>
                                        Prosseguir
                                        </button>
                                    </div>
                        </CaixaEsqueciSenha>
                        <ToastContainer />
                    </div>
                </div>
                }/>
        </div>
    );
    }

                        
                        
                        
           
           