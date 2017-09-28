Array.prototype.unique = function ()
{

    var self = this;
    self.sort();
    //首先定义一个数组，默认第一个元素一定不存在重复
    var re = [self[0]];
    for (var i =1; i < self.length; i++)
    {
        //从第一个元素开始与前一个比较，如果不相同就插入到re中
        if (self[i] !== re[re.length - 1]) {
            re.push(self[i]);
        }
      
    }
    return re;
}