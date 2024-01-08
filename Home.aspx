<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Lab3.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
        <style>


         .main_content{
             padding-bottom:50px;
         }   
        .header {
            font-size: 24px;
            font-weight: bold;
            margin-bottom: 20px;
            color: #333;
        }
        .dashboard-chart-container {
            background-color: #f5f5f5; 
            padding: 10px;
            border-radius: 8px;
            margin-bottom: 20px;
        }

 
        .summary-card {
            border: 1px solid #ddd;
            padding: 10px; 
            margin: 5px; 
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            text-align: center;
            transition: background-color 0.3s ease;
            color: #fff; 
        }
    </style>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="bodycontent" runat="server">
    <div class="main_content">
        <div class="header">Dashboard <%= Session["Username"] %></div>
        <div class="info">
            <div class="dashboard-chart-container">
                <div class="row">
                    <div class="col-md-6">
                        <canvas id="myChart" width="200" height="100"></canvas>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <asp:Chart ID="Chart1" runat="server" BackColor="#f5f5f5">
                            <Series>
                                <asp:Series Name="Series1" Font="Arial, 12pt" IsValueShownAsLabel="true"></asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1" BackColor="White">
                                    <Area3DStyle Enable3D="false" />
                                </asp:ChartArea>
                            </ChartAreas>
                            <Titles>
                                <asp:Title Font="Arial, 16pt" Text="Schedule Overview"></asp:Title>
                            </Titles>
                        </asp:Chart>
                    </div>
                </div>
            </div>
            <div class="dashboard-summary row">
                <div class="col-md-6">
                    <!-- Department Card -->
                    <div class="summary-card" style="background-color: #4b4276;">
                        <h4>Departments</h4>
                        <asp:Literal ID="litDepartments" runat="server"></asp:Literal>
                    </div>

                    <!-- User Card -->
                    <div class="summary-card" style="background-color: #54a0ff;">
                        <h4>Users</h4>
                        <asp:Literal ID="litUsers" runat="server"></asp:Literal>
                    </div>
                </div>

                <div class="col-md-6">
                    <!-- Day Schedule Card -->
                    <div class="summary-card" style="background-color: #ffd700;">
                        <h4>Schedules (Day)</h4>
                        <asp:Literal ID="litDaySchedules" runat="server"></asp:Literal>
                    </div>

                    <!-- Night Schedule Card -->
                    <div class="summary-card" style="background-color: #50c878;">
                        <h4>Schedules (Night)</h4>
                        <asp:Literal ID="litNightSchedules" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script>
        var ctx = document.getElementById('myChart').getContext('2d');
        var myChart = new Chart(ctx, {
            type: 'bar',
            data: {
                labels: ['Departments', 'Users', 'Schedules (Day)', 'Schedules (Night)'],
                datasets: [{
                    label: 'Counts',
                    data: [<%= litDepartments.Text %>, <%= litUsers.Text %>, <%= litDaySchedules.Text %>, <%= litNightSchedules.Text %>],
                    backgroundColor: [
                        'rgba(255, 99, 132, 0.7)',
                        'rgba(54, 162, 235, 0.7)',
                        'rgba(255, 206, 86, 0.7)',
                        'rgba(75, 192, 192, 0.7)'
                    ],
                    borderColor: [
                        'rgba(255,99,132,1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(255, 206, 86, 1)',
                        'rgba(75, 192, 192, 1)'
                    ],
                    borderWidth: 1
                }]
            },
            options: {
                maintainAspectRatio: false, 
                responsive: true, 
                scales: {
                    y: {
                        beginAtZero: true,
                        ticks: {
                            font: {
                                size: 10
                            }
                        }
                    },
                    x: {
                        ticks: {
                            font: {
                                size: 10
                            }
                        }
                    }
                }
            }
        });
    </script>
</asp:Content>
