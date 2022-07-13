import { DishDTO } from "./DishDTO";

export class RestaurantDTO {
    // public long Id { get; set; }
    //     public string RestName { get; set; }

    //     public int Stars { get; set; }

    //     public List<DishDTO> Dishes { get; set; }


    Id : number;
    RestName : string;
    Stars : number;
    Dishes : DishDTO[];

    constructor() {
        this.Id = 0;
        this.Stars = 0;
        this.RestName = "";
        this.Dishes = [];
    }

}