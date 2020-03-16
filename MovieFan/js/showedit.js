document.addEventListener('DOMContentLoaded', function () {

    //Toggle Show/Edit movie
    cmdEdit.addEventListener('click', function () {
        divShow.classList.add('d-none')
        divEdit.classList.remove('d-none')
    })

    cmdCancel.addEventListener('click', function () {
        divShow.classList.remove('d-none')
        divEdit.classList.add('d-none')
    })

    cmdDelete.addEventListener('click', function () {
        frmDelete.submit()
    })
})