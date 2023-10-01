<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tester.aspx.cs" Inherits="Front.tester" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

<%-- 
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
<script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js" integrity="sha384-IQsoLXl5PILFhosVNubq5LC7Qb9DXgDA9i+tQ8Zj3iwWAwPtgFTxbJ8NT4GN1R8p" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.min.js" integrity="sha384-cVKIPhGWiC2Al4u+LWgxfKTRIcfu0JTxR+EQDz/bgldoEyl4H0zUF0QKbrJ0EcQF" crossorigin="anonymous"></script>    
           <link href="../Libs/all.css" rel="stylesheet" /> --%>
<%--    <link href="../Libs/bulma.min.css" rel="stylesheet" />--%>
    <link href="https://cdn.datatables.net/1.13.6/css/jquery.dataTables.min.css" rel="stylesheet" />
    <%--    <link href="../Libs/dataTables.bulma.min.css" rel="stylesheet" />
        <script src="../Libs/dataTables.bulma.min.js"></script>--%>

        <%--<script src="https://code.jquery.com/jquery-3.7.0.js"></script>
    
        <link href="../Libs/jquery.dataTables.min.css" rel="stylesheet" />
        <script src="https://cdn.datatables.net/1.13.6/js/jquery.dataTables.min.js"></script>
        <script src="../Libs/jquery.mCustomScrollbar.concat.min.js"></script>
        <link href="../Libs/jquery.mCustomScrollbar.min.css" rel="stylesheet" />
        <script src="../Libs/jquery.min.js"></script>
        <link href="../Libs/main.css" rel="stylesheet" />
        <script src="../Libs/main.js"></script>
        <link href="../Libs/sidebar-themes.css" rel="stylesheet" />--%>

       <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description"
        content="Responsive sidebar template with sliding effect and dropdown menu based on bootstrap 3">

      <link href="Libs/jquery.dataTables.min.css" rel="stylesheet" />
     <script src="Libs/bootstrap.min.js"></script>
        <script src="Libs/jquery.min.js"></script>
        <script src="Libs/popper.min.js"></script>
        <script src="Libs/jquery.mCustomScrollbar.concat.min.js"></script>
        <script src="Libs/main.js"></script>
        <script src="Libs/jquery-3.3.1.slim.min.js"></script>
        <script src="Libs/jquery.dataTables.min.js"></script>
        <link href="Libs/bootstrap.min.css" rel="stylesheet" />
        <link href="Libs/jquery.mCustomScrollbar.min.css" rel="stylesheet" />
        <link href="Libs/all.css" rel="stylesheet" />
        <link href="Libs/main.css" rel="stylesheet" />
        <link href="Libs/sidebar-themes.css" rel="stylesheet" />
        <script src="Libs/dataTables.bulma.min.js"></script>





   
    <link href="Libs/bulma.min.css" rel="stylesheet" />
  
        <link href="Libs/dataTables.bulma.min.css" rel="stylesheet" />










              <script type="text/javascript">

                  $(document).ready(function () {

                      $(document).ready(function () {
                          $('#Gridview1').DataTable();
                      });
                      $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
                      $('.table1').DataTable();
                  });

              </script>
    <style>

        .table {
   background-color: white;
   color: black;
   
 }


    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

               <!DOCTYPE html>
        <div class="row">
                        <div class="col-12">


    <asp:DataGrid runat="server" ID="DataGridUsers" Width="100%" class="table table-striped dt-responsive table-hover border-0 ">



    </asp:DataGrid>
   
</div>
</div>

    <br />

        <script>

            new DataTable('.table');
      
        </script>




        </div>
    </form>
</body>
</html>
