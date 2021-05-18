$(document).ready(function () {
    $('#tableResultBob').DataTable();

    $('#idBobineFormCapacite').select2({
        theme: "bootstrap4",
        width: "100%",
        ajax: {
            url: '/Home/GetBobineRefForSelect2',
            processResults: function (data) {
                return data
            }
        }
    });
});

async function showModalDeleteBobine(idBobine) {
     let response = await fetch("https://localhost:44346/Bobines/Delete/" + idBobine);
     let data = await response.text();

     $("#contentBobineResult").html(data);
     $("#modalDeleteBobine").modal("show");
}

function showResultCapaciteBobine() {
    let refBob = $("#refBobFormCapacite").val();
    let diametreCable = $("#diametreCableFormCapacite").val();
    let largeurCable = $("#largeurCableFormCapacite").val();
    let epaisseurCable = $("#epaisseurCableFormCapacite").val();
    let coeff = $("#coeffFormCapacite").val();
    let poidsCable = $("#poidsCableFormCapacite").val();

    let model = {
        Bobine: { IdBobine: 2 },
        Cable: {
            TypeCable: "rond",
            Diametre: diametreCable,
            Largeur: largeurCable,
            Epaisseur: epaisseurCable,
            CoeffRemplissage: coeff,
            PoidsCable: poidsCable,
        }
    }

    $.ajax({
        url: "/Home/SimulationCapaciteBobResult",
        type: "post",
        data: model,
        success: function (response) {
            $("#resultSimulationCapacite").html(response);
        }
    })
}

function showResultDimensionBobine() {
    let largeurExt = $("#largeurExtFormDimension").val();
    let largeurInt = $("#largeurIntFormDimension").val();
    let diametreExt = $("#diametreExtFormDimension").val();
    let diametreInt = $("#diametreIntFormDimension").val();
    let moyeu = $("#moyeuFormDimension").val();
    let poidsBobVide = $("#poidsBobVideFormDimension").val();
    let poidsBobMax = $("#poidsBobMaxFormDimension").val();
    let diametreCable = $("#diametreCableFormDimension").val();
    let largeurCable = $("#largeurCableFormDimension").val();
    let epaisseurCable = $("#epaisseurCableFormDimension").val();
    let coeff = $("#coeffFormDimension").val();
    let poidsCable = $("#poidsCableFormDimension").val();

    let model = {
        Bobine: {
            Trancanage: true,
            Enroulement: false,
            LargeurExt: largeurExt,
            LargeurInt: largeurInt,
            DiametreExt: diametreExt,
            DiametreInt: diametreInt,
            Moyeu: moyeu,
            PoidsAVide: poidsBobVide,
            PoidsMaxAutorise: poidsBobMax,
        },
        Cable: {
            TypeCable: "rond",
            Diametre: diametreCable,
            Largeur: largeurCable,
            Epaisseur: epaisseurCable,
            CoeffRemplissage: coeff,
            PoidsCable: poidsCable,
        }
    }

    $.ajax({
        url: "/Home/SimulationDimensionBobResult",
        type: "post",
        data: model,
        success: function (response) {
            $("#resultSimulationDimensionBob").html(response);
        }
    })
}

function showResultRechercheBobine() {
    let diametreCable = $("#diametreCableFormRecherche").val();
    let largeurCable = $("#largeurCableFormRecherche").val();
    let epaisseurCable = $("#epaisseurCableFormRecherche").val();
    let coeff = $("#coeffFormRecherche").val();
    let poidsCable = $("#poidsCableFormRecherche").val();
    let longueurCable = $("#longueurCableFormRecherche").val();
    let nonSecable = $("#nonSecableFormRecherche").is(":checked");

    let model = {
        TypeCable: "rond",
        Diametre: diametreCable,
        Largeur: largeurCable,
        Epaisseur: epaisseurCable,
        CoeffRemplissage: coeff,
        PoidsCable: poidsCable,
        LongueurCable: longueurCable,
        CaseNonSecable: nonSecable
    }

    $.ajax({
        url: "/Home/SimulationRechercheBobResult",
        type: "post",
        data: model,
        success: function (response) {
            $("#resultSimulationRecherche").html(response);
        }
    })
}
