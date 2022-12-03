$(function()
{
    let filter1Array = ["iduserFilter1", "idregionFilter1", "datestartFilter1", "dateendFilter1", "buttonFilter1"];
    let filter2Array= ["idregionFilter2", "datestartFilter2", "dateendFilter2", "buttonFilter2"];
    let [menuValidation, menuButton, filter1, filter2]  = 
    [$("#menuValidation"), $("#menuButton"), $("#filter1"), $("#filter2")]
    filter1.append(`
        <label class="labelMenu">Поиск</label>
        `)
    for(let x=0;x<2;x++)
    {
        filter1.append(`
        <div class="col-3">
            <div class="form-floating mb-3">
                <input type="email" class="form-control" id="${filter1Array[x]}" placeholder="name@example.com">
                <label for="${filter1Array[x]}">${filter1Array[x]}</label>
            </div>
        </div>
        `)
    }
    
    filter2.append(`
    <div class="col-4">
        <div class="form-floating mb-3">
        <input type="email" class="form-control" id="${filter2Array[0]}" placeholder="name@example.com">
        <label for="${filter2Array[0]}">${filter2Array[0]}</label>
        </div>
    </div>
    `)
    for(let x =2; x <4;x++)
    {
        filter1.append(`
            <div class="col-3">
                <div class="form-floating mb-3">
                    <input id="${filter1Array[x]}" class="form-control" type="date">
                    <label for="${filter1Array[x]}">${filter1Array[x]}</label>
                </div>
            </div>
        `)

        filter2.append(`
            <div class="col-4">
                <div class="form-floating mb-3">
                    <input id="${filter2Array[x]}" class="form-control" type="date">
                    <label for="${filter2Array[x]}">${filter2Array[x]}</label>
                </div>
            </div>
        `)
    }

    filter1.append(`<button type="button" class="btn btn-success" id="${filter1Array[4]}" onclick="sendForm1(this)" style="width: 50%;
    margin-left: 11rem;">поиск по user</button>`)
    filter2.append(`<button type="button" class="btn btn-success" id="${filter2Array[3]}" onclick="sendForm2(this)" style="width: 50%;
    margin-left: 11rem;">поиск по region</button>`)

    
})

window.pager = 0;

function sendForm1(element)
    {
    let inputArrey = $("#" + element.id).parent().parent().parent().find("input");
    let objectForm1 = new Object();

    objectForm1["UserId"] = $("#" + inputArrey[0].id).val();
    objectForm1["AreaId"] = $("#" + inputArrey[1].id).val()
    objectForm1["IsMore"] = false
    objectForm1["DateStart"] = $("#" + inputArrey[2].id).val()
    objectForm1["DateEnd"] = $("#" + inputArrey[3].id).val()
    objectForm1["Page"] = pager
    console.log(objectForm1)
    ajaxSend(objectForm1);
    }

function sendForm2(element)
{
    let inputArrey = $("#" + element.id).parent().parent().parent().find("input");
    let idregion = $("#" + inputArrey[0].id).val()
    let dataStart = $("#" + inputArrey[1].id).val()
    let dataEnd = $("#" + inputArrey[2].id).val()
    alert(idregion + dataStart + dataEnd)
    // ajaxSend();
}

$(window).scroll(function (event) 
{
    var scroll = $(window).scrollTop();
    let height = $(document).height() - $(window).height() - 20;
    if(scroll  > height) {
        pager++;
        console.log(scroll);
    }
    
});

let baseUrl = "http://localhost:8000/"
function ajaxSend(objectForm1)
{
    $.ajax({
        url: baseUrl + 'api/VipPony/FilerList',         /* Куда отправить запрос */
        method: 'post',             /* Метод запроса (post или get) */
        dataType: 'json',         /* Тип данных в ответе (xml, json, script, html). */
        data: { model: objectForm1},     /* Данные передаваемые в массиве */
        success: function(data){   /* функция которая будет выполнена после успешного запроса.  */
             alert(data); /* В переменной data содержится ответ от index.php. */
        }
    });
}