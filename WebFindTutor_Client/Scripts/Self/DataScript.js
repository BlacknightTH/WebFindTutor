$(document).ready(function () {
    $('#AmphurTable').DataTable({
        "pagingType": "full_numbers",
        "scrollX": true,
        "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]]
    });
    $('#DistrictTable').DataTable({
        "pagingType": "full_numbers",
        "scrollX": true,
        "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]]
    });
    $('#GeographyTable').DataTable({
        "pagingType": "full_numbers",
        "scrollX": true,
        "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]]
    });
    $('#AdminInstructorTable').DataTable({
        "pagingType": "full_numbers",
        "scrollX": true,
        "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]]
    });
    $('#ProvinceTable').DataTable({
        "pagingType": "full_numbers",
        "scrollX": true,
        "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]]
    });
    $('#ZipcodeTable').DataTable({
        "pagingType": "full_numbers",
        "scrollX": true,
        "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]]
    });
});