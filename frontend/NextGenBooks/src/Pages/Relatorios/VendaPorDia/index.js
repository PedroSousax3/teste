import React, { useState } from 'react';
import Master from '../../Master/index.js';
import { ContainerVendaDia, Containerinput } from '../style.js';
import { ToastContainer, toast } from "react-toastify";
import NextGenBooks from '../../../Service/NextGenBookApi.js';
import { useHistory, Link } from "react-router-dom";

const api = new NextGenBooks();

export default function VendaPorDia() {
    const [Dia, setDia] = useState(new Date().toISOString().substr(0, 10));
    const [registros, setRegistros] = useState([]);

    const listar = async () => {
        try {
            let request = {
                Dia
            }
            let resp = await api.relatorioVendaDia(request);
            setRegistros([...resp]);
        } catch (e) {
            toast.error(e);
        }
    }

    return (
        <Master>
            <ContainerVendaDia>
                        <Containerinput>
                            <div>
                                <h6>
                                Selecione uma data e descubra quantas vendas foram realizadas no dia escolhido.
                                </h6>
                            </div>
                            <div className="form-group" style={{display:"flex",marginTop:"10%",flexDirection:"row",justifyContent:"space-around"}}>
                                <label className="Data">Escolha a data:</label>
                                <input className="form-control" type="date"  onChange={(n) => setDia(n.target.value)} />
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
                                <th scope="col">Cliente</th>
                                <th scope="col">Data</th>
                                <th scope="col">Hora</th>
                                <th scope="col">Quantidade de Produtos</th>
                                <th scope="col">Total de Produtos</th>
                                <th scope="col">Total da Compra</th>
                                <th scope="col">Endereço de Entrega</th>
                                <th scope="col"></th>
                            </tr>
                        </thead>

                        <tbody>
                            {registros.map((item) =>
                                <tr key={item.nomeCliente}>
                                    <th scope="row" style={{textAlign:"center"}}>{item.nomeCliente}</th>
                                    <td style={{textAlign:"center"}}>{item.diaDaVenda}</td>
                                    <td style={{textAlign:"center"}}>{item.hora}</td>
                                    <td style={{textAlign:"center"}}>{item.qtdProdutosDiferentes}</td>
                                    <td style={{textAlign:"center"}}>{item.qtdTotalDeProdutos}</td>
                                    <td style={{textAlign:"center"}}>{item.totalCompra}</td>
                                    <td style={{textAlign:"center"}}>{item.enderecoDeEntrega}</td>
                                    <td>
                                        <Link
                                            to={{
                                                state: {
                                                    livros:item.livros
                                                },
                                                pathname: "/LivroVenda"
                                            }}
                                        >
                                            <button id="btcompra" type="button" className="btn btn-success" >Livros</button>
                                        </Link>
                                    </td>
                                </tr>




                            )}
                        </tbody>
                    </table>

                </div>
            </ContainerVendaDia>
            <ToastContainer />
        </Master>
    )
}                   