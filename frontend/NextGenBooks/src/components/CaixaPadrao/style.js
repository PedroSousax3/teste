import styled from 'styled-components';

export const CaixaPadrao = styled.div`
    background-color: rgb(152, 240, 187);
    width: 60%;
    height: 65vh;
    display: flex;
    flex-direction: column;

    justify-content:center;
    align-items:center;
    border-radius:10px;
    box-shadow:10px 10px 5px 0px rgb(0,0,0,0.2);
    
    .form-row{

        width:78%;
    }

@media screen and (max-width: 600px)
{
 
    & {
        padding: 0px 0vw 0px 0vw;
        height: 100vh;
        width:100%;
        background-color:white;
        box-shadow:none;
      
    }
    & > .form-row > .col > .form-control{
        margin-top: 10px;
        margin-bottom: px;
    }

    & > .form-row{
        flex-direction: column;
        display:flex;
        min-height:25%;
        width:100%;
    }
    & > .form-row > .col-4 > .form-control{
        min-height:15%;
        width:100%;
    }
    & > .form-row{
        width:100%;

  
    }
    & > .form-row > .col-4 > .form-control{
        max-width:100.333333%;
    }
    & > .form-row > .col-4{
        max-width:100.333333%;
    }
    & > .row > .col-sm-10 > .form-control {
        margin-right:0px;
        margin-left: -45px;
        width: 110%;
        margin-top:2px;
        margin-bottom:-11px;
    }
   
}
    & > .form-control{
        margin-top:5px;
        margin-bottom:7px;
    }
    `;