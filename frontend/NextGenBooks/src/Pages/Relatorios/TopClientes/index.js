import React ,{useState} from 'react';
import Master from '../../Master/index.js';
import {ContainerVendaDia,Containerinput} from '../style.js';
import { ToastContainer, toast } from "react-toastify";
import NextGenBooks from '../../../Service/NextGenBookApi';
import { useHistory, Link } from "react-router-dom";

let api = new NextGenBooks();
export default function TopClientes(){
const [registros,setRegistros] = useState([]);




    const listar = async () =>{
        try{
            let resp = await api.TopCliente();
            setRegistros([...resp]);
        }catch(e){
            toast.error(e.response.erro);
        }
    }
    return(
        <Master>
            <ContainerVendaDia>
                        <Containerinput>
                            <div className="form-group">
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
                            <table className="table table-striped">
                                <thead>
                                    <tr>
                                        <th scope="col">Nome</th>
                                        <th scope="col">Email</th>
                                        <th scope="col">Telefone</th>
                                        <th scope="col">Quantidade de Compras</th>
                                        <th scope="col">Total de Gasto</th>
                                    </tr>
                                </thead>

                                <tbody>
                                    {registros.map((item) =>
                                        <tr className="table" key={item.nome}>
                                            <th scope="row">{item.nome}</th>
                                            <td>{item.email}</td>
                                            <td>{item.telefone}</td>
                                            <td>{item.qtdCompras}</td>
                                            <td>{item.totalGasto}</td>
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