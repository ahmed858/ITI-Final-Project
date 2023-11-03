
    $(document).ready(function () {
        $("#RoleName").on("change", function () {
            if ($(this).val() != "Doctor") {
                $(".SpecialistDoctordiv").hide();
            } else {
                $(".SpecialistDoctordiv").show();
            }
        });
    });
