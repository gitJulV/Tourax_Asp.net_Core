 async function showModalDeleteBobine(idBobine) {
     let response = await fetch("https://localhost:44346/Bobines/Delete/" + idBobine);
     let data = await response.text();

     $("#contentBobineResult").html(data);
     $("#modalDeleteBobine").modal("show");
}
