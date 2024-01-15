
using HomeWork;

Helper helper = new Helper();

var  Data=await helper.GetHttpData(d=>d.id==1||d.id==10||d.id==100);


 helper.AddDataFile(Data);