$(document).ready(function() {
    getCbxProduto();
});

function getCbxProduto(){
    $.ajax({
        type: "GET",
        url: "https://localhost:44363/api/Produto",
        dataType: "json",
        success: function(data) {
                var div = `<option value="">Selecione um produto</option>`;
            $(data).each(function (index) {
                div += `<option value="${data[index].id}" valor="${data[index].preco}">${data[index].nome}</option>`
            });
            $("#produto").html(div);
        },
        error: function(data) {
            alert("Error!");
            alert(data);
        }
    });
}

function adicionarSacola(){
    var element = $("#produto").find('option:selected'); 
    var produto = element.text();
    var valor = element.attr("valor")
    valor = Number(valor) * Number($("#quantidade").val())

    var div = "";
    div += `<tr>
        <td>${produto}</td>
        <td>${$("#quantidade").val()}</td>
        <td>${"R$ "+valor}</td>
    </tr>`
    $("#sacola").html($("#sacola").html() + div);

    $("#valorTotal").val(Number($("#valorTotal").val())+valor);
    $("#quantidadeTotal").val(Number($("#quantidadeTotal").val())+Number($("#quantidade").val()));
    $("#produto").val("");
    $("#quantidade").val("");
}

function postNota(){
    if(regras()){
        if($("#cupom_fiscal").val().slice(-3) == "pdf" || $("#cupom_fiscal").val().slice(-3) == "jpg" || $("#cupom_fiscal").val().slice(-3) == "png" && Number($("#quantidadeTotal").val()) >= 6 && $("#data").val() >= "2022-05-01" && $("#data").val() <= "2022-06-15"){
            $.ajax({
                type: "POST",
                url: "https://localhost:44363/api/NotaFiscal",
                dataType: "json",
                data: JSON.stringify({
                    produtos: $("#sacola").html(),
                    quantidade: Number($("#quantidadeTotal").val()),
                    valor_total: Number($("#valorTotal").val()),
                    cnpj: $("#cnpj").val(),
                    n_cupom: $("#cupom").val(),
                    canal_compra: $("#canal").val(),
                    data_compra: $("#data").val(),
                    img_nf: $("#cupom_fiscal").val()
                }),
                contentType: "application/json; charset=utf-8",
                success: function(data) {
                    alert("Cadastro feito com sucesso!");
                    location.reload();
                },
                error: function(data) {
                    alert("Error!");
                    alert(data);
                }
            });
        }
        else{
            alert("Cupom fiscal inválido!");
        }
    }
}

function regras(){
    var passou = true
    if(Number($("#quantidadeTotal").val()) < 6){
        alert ("A quantidade mínima de produtos é 6!");
        passou = false;
    }

    if(!($("#data").val() >= "2022-05-01" && $("#data").val() <= "2022-06-15")){
        alert ("A data precisa ser entre 01/05/2022 e 15/06/2022!");
        passou = false;
    }

    if($("#cupom_fiscal").val().slice(-3) != "pdf" && $("#cupom_fiscal").val().slice(-3) != "jpg" && $("#cupom_fiscal").val().slice(-3) != "png"){
        alert ("O arquivo deve ser um pdf, jpg ou png!");
        passou = false;
    }
    return passou;
}

function formataCnpj(){
    var cnpj = $("#cnpj").val();
    cnpj = cnpj.slice(0,2)+"."+cnpj.slice(2,5)+"."+cnpj.slice(5,8)+"/"+cnpj.slice(8,12)+"-"+cnpj.slice(12,14);
    $("#cnpj").val(cnpj);
}