<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Uzorak extends Model
{
    protected $table = 'uzorci';
    protected $guarded = ['id','created_at'];
}
