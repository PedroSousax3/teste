import React, { useState } from 'react';
import Master from '../../Master/index.js';
import { ContainerVendaDia, Containerinput } from '../style';
import { ToastContainer, toast } from "react-toastify";
import NextGenBooks from '../../../Service/NextGenBookApi.js';
import { useHistory, Link } from "react-router-dom";

const api = new NextGenBooks();

export default function TopVenda() {
    const [Dia, setDia] = useState(new Date().toISOString().substr(0, 10));
    const [registros, setRegistros] = useState([]);

    const listar = async () => {
        try {
            let resp = await api.TopVendas();
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
                        <h2>
                            Top 10 Livros
                                </h2>
                    </div>
                    <div className="botao">
                        <button
                            className="btn"
                            onClick={listar}
                        >
                            CONSULTAR

                                </button>
                    </div>
                </Containerinput>
                <div>
                    <table className="table table-striped" style={{ marginTop: "10%" }}>
                        <thead>
                            <tr>
                                <th scope="col">Produto</th>
                                <th scope="col">Quantidade</th>
                                <th scope="col">Total</th>
                            </tr>
                        </thead>

                        <tbody>
                            {registros.map((item) =>
                                <tr key={item.nomeCliente}>
                                    <th scope="row" style={{ textAlign: "center" }}>{item.produto}</th>
                                    <td style={{ textAlign: "center" }}>{item.produto}</td>
                                    <td style={{ textAlign: "center" }}>{item.quantidadeVenda}</td>
                                    <td style={{ textAlign: "center" }}>{item.TotalGasto}</td>
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