
//$("").on("click", function (e) {

//    console.log("salam")
//    var url = e.target.href;

//    console.log(url)
//    e.preventDefault()
//    fetch(url)
//        .then(response => response.text())
//        .then(data => {
//            $('.product-modal-area').html(data);
//        })

//})


$(document).on("click", "#get-modal", function (e) {

    e.preventDefault()
    var url = e.target.href;

    console.log(url)
    console.log("salam")
    fetch(e.target.href)
        .then(response => response.text())
        .then(data => {
            $('.product-modal-area').html(data);
        })


    $("#quickModal").modal("show");

})
