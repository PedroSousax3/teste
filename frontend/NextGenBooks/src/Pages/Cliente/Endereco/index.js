import React,{useState } from "react";
import Master from "../../Master";
import {CaixaPadrao} from "../../../components/CaixaPadrao/style";
import {ContainerEndereco} from "./style";
import {buscarEndereco} from "../../../Service/ApiCorreio";
import {ContainerBotao} from "./style"
import nextGenBookAPI from "../../../Service/NextGenBookApi";
import { ToastContainer, toast } from "react-toastify";
import Cookies from 'js-cookie';

const api = new nextGenBookAPI();
export default function CadastrarEndereco(props)
{
    const idCliente = Number(Cookies.get('id'));

    const [nome,setNome] = useState("");
    const [endereco,setEndereco] = useState("");
    const [numero,setNumero] = useState();
    const [complemento,setComplemento] = useState("");
    const [cep,setCep] = useState("");
    const [cidade,setCidade] = useState("");
    const [estado,setEstado] = useState("");
    const [celular,setCelular] = useState("");

    function limpa_formulário_cep() {
        setCidade("");
        setEstado("");
        setEndereco("");
        setCep("");
    }
    
    function meu_callback(conteudo) {
        if (!("erro" in conteudo) ) {
            setCidade(conteudo.localidade);
            setEndereco(conteudo.logradouro + " - " + conteudo.bairro);
            setEstado(conteudo.uf);
            setCep(conteudo.cep)
        } 
        else {
            limpa_formulário_cep();
            alert("CEP não encontrado.");
        }
    }

    const preencherCampos = async (e) => {
        if(e.target.value.length === 8)
        {
            let response = await buscarEndereco(e.target.value);
            if(response != null)
            {
                meu_callback(response);
            }
        }
    }           

    const cadastrar = async () =>{
        try
        {
            let request = {
                cliente: idCliente,
                nome,
                endereco,
                numero,
                complemento,
                cep,
                cidade,
                estado,
                celular
            }
            let response  = await api.cadastrarEndereco(request);
            if(response.status === 200)
                toast.success("Endereço cadastrado com sucesso, você pode verificar em seu perfil.");
            else
                toast.error(response.statusText);
        }
        catch (ex) 
        {
            toast.error(ex.response.data.erro);
        }
    }

 
    return(
            <div>
                <Master>
                    <ContainerEndereco>
                        <CaixaPadrao>
                            <h3 style={{marginBottom:"5%",color:"#D26E4E",fontWeight:"bold" }}>CADASTRAR ENDEREÇO</h3>
                            <div className="form-row">
                                <div className="col-4">
                                <input type="text" id="cep" name="cep" className="form-control" placeholder="CEP" maxLength="10" onChange={(e) => preencherCampos(e) } /*onKeyPress={preencherCampos}*/ />
                                </div>

                                <div className="col">
                                    <input type="text" id="cidade" className="form-control" placeholder="Cidade" value={cidade}  onChange={(e) => setCidade(e.target.value)} />
                                </div>

                                <div className="col">
                                <input type="text" id="estado" className="form-control" placeholder="Estado" value={estado}  onChange={(e) => setEstado(e.target.value)}/>
                                </div>

                            </div>

                                <div className="form-group row" style={{width:"97%",marginTop:"2%",marginLeft:"14%"}}>
                                <div className="col-sm-10">
                                <input type="text" className="form-control" id="endereco" placeholder="Endereço" value={endereco}  onChange={(e) => setEndereco(e.target.value)}/>
                                </div>

                                </div>

                            <div className="form-group row" style={{width:"97%",marginLeft:"14%"}}>
                                <div className="col-sm-10">
                                    <input type="text" className="form-control" id="endereco" placeholder="Celular"  onChange={(e) => setCelular(e.target.value)}/>
                                </div>
                            </div>

                            <div className="form-row" >
                                <div className="col-4">
                                    <input type="text" className="form-control" placeholder="Complemento"  onChange={(e) => setComplemento(e.target.value)}/>
                                </div>
                                <div className="col-4">
                                    <input type="number" className="form-control" placeholder="Número" min="1" onChange={(e) => setNumero(e.target.value)}/>
                                </div>
                                <div className="col">
                                    <input type="text" className="form-control" id="inputPassword" placeholder="Descrição"  onChange={(e) => setNome(e.target.value)}/>
                                </div>
                            </div>
                            <ContainerBotao>
                            <div className="botao">
                                    <button
                                    className="btn"
                                        onClick={cadastrar}
                                    >
                                        Cadastrar Endereço
                                    </button>
                            </div>
                            </ContainerBotao>
                        </CaixaPadrao>
                    </ContainerEndereco>
                    <ToastContainer />
                </Master>
            </div>
    );
}
                        
                                
