在 "程序包管理器控制台" 中选中 "LZ.Model" 
输入 :
Scaffold-DbContext "server=.;database=LZ;uid=sa;pwd=123456;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Force  -Context EntityContext -ContextDir EntityContext

LZ.sql 是数据库结构