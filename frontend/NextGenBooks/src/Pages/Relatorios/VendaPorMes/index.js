import React ,{useState} from 'react';
import Master from '../../Master/index.js';
import {ContainerVendaDia,Containerinput} from '../style.js';
import { ToastContainer, toast } from "react-toastify";
import NextGenBooks from '../../../Service/NextGenBookApi';
import { useHistory, Link } from "react-router-dom";

let api = new NextGenBooks();
export default function VendaPorMes(){
const [MesInicio, setMesInicio] = useState(new Date());
const [MesFim, setMesFim] = useState(new Date());
const [registros,setRegistros] = useState([]);




    const listar = async () =>{
        try{
            let request = {
                MesInicio,
                MesFim
            }
            let resp = await api.relatorioVendaMes(request);
            setRegistros([...resp]);
        }catch(e){
            toast.error(e.response.erro);
        }
    }
    return(
        <Master>
            <ContainerVendaDia>
                        <Containerinput>
                             <div>
                                <h3>
                                   Vendas Do Mês
                                </h3>
                            </div>
                            <div className="form-group" style={{display:"flex",flexDirection:"row"}}>
                                <label className="Data">Escolha a Data:</label>
                                <label className="Data">Início:</label>
                                <input className="form-control" type="date" onChange={(n) => setMesInicio(n.target.value)} />
                                <label className="Data">Fim:</label>
                                <input className="form-control" type="date" onChange={(n) => setMesFim(n.target.value)} />
                                <div className="botao">
                                <button
                                  className="btn"
                                    onClick={listar}
                                >
                                    CONSULTAR
                                </button>
                          </div>
                            </div>
                        </Containerinput>
                        <div>
                            <table className="table table-striped" style={{marginTop:"10%"}}>
                                <thead>
                                    <tr>
                                        <th scope="col">Mês</th>
                                        <th scope="col">Quantidade de Vendas</th>
                                        <th scope="col">Total Vendas</th>
                                    </tr>
                                </thead>

                                <tbody>
                                    {registros.map((item) =>
                                        <tr>
                                            <th scope="row" style={{textAlign:"center"}}>{item.mes}</th>
                                            <td style={{textAlign:"center"}}>{item.qtdVendas}</td>
                                            <td style={{textAlign:"center"}}>{item.totalVenda}</td>
                                        </tr>
                                          )}
                                      </tbody>
                                  </table>
      
                              </div>
                  </ContainerVendaDia>
                  <ToastContainer/>
              </Master>
          )
      }
                                          
                                 

