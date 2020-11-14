import React ,{useState} from 'react';
import Master from '../../../Master';
import {ContainerVendaDia,Containerinput} from '../../style.js';
import { ToastContainer, toast } from "react-toastify";
import NextGenBooks from '../../../../Service/NextGenBookApi';
import { useHistory, Link } from "react-router-dom";

let api = new NextGenBooks();
export default function LivroVendaRelatorio(props){
const [registros,setRegistros] = useState([...props.location.state.livros]);

    return(
        <Master>
            <ContainerVendaDia>
                     
                        <div>
                            <h1>Produtos Dessa Venda</h1>
                            <table className="table table-striped" style={{marginTop:"10%"}}>
                                <thead>
                                    <tr>
                                        <th scope="col"style={{textAlign:"center"}}>Nome Do Livro</th>
                                        <th scope="col"style={{textAlign:"center"}}>Quantidade</th>
                                        <th scope="col"style={{textAlign:"center"}}>Valor</th>
                                        
                                    </tr>
                                </thead>

                                <tbody>
                                    {registros.map((item) =>
                                        <tr key={item.nomeLivro}>
                                            <th scope="row" style={{textAlign:"center"}}>{item.nomeLivro}</th>
                                            <th scope="row" style={{textAlign:"center"}}>{item.qtdUnitaria}</th>
                                            <td style={{textAlign:"center"}}>R$ {item.valorUnitario}</td>
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