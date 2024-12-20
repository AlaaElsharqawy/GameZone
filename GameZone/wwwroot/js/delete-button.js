$(document).ready(function () {

    $('.js-delete').on('click', function () {
        var btn = $(this);

        const swal = Swal.mixin({
            customClass: {
                confirmButton: "btn btn-primary mx-2",
                cancelButton: "btn btn-light"
            },
            buttonsStyling: false
        });

        swal.fire({
            title: 'Are you sure That you need to delete this game?',
            text: 'You wont be able to revert this!',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Yes, delete it!',
            cancelButtonText: 'No, cancel!',
            reverseButtons: true
        }).then((result) => {
            if (result.isConfirmed) {

                $.ajax({
                    url: `/Games/Delete/${btn.data('id')}`,
                    method: 'DELETE',
                    success: function () {
                        swal.fire(
                            'Deleted!',
                            'Game has been deleted.',
                            'success'
                        );

                        btn.parents('tr').fadeOut();
                    },

                    error: function () {
                        swal.fire(
                             'Oooops..!',
                             'some thing went wrong',
                             'error'
                        );
                    }
                });

    } 
            
        });
   
    });
});
      
   
