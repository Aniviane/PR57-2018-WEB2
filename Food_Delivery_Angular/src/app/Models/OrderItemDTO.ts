export class OrderItemDTO {
    // public long Id { get; set; }
    //     public long DishId { get; set; }
    //     public long OrderId { get; set; }

    //     public string DishComment { get; set; }

    Id : number;
    DishId : number;
    OrderId : number;
    DishComment : string;

    constructor(dish:number,comment:string) {
        this.Id = 0;
        this.DishId = dish;
        this.OrderId = 0;
        this.DishComment = comment;
    }
}