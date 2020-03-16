document.addEventListener('DOMContentLoaded', function () {

    // Hide flashmessage
    if (document.getElementById('flashmessage'))
        setTimeout(function () {
            flashmessage.classList.add('d-none')
        }, 3000)
})
