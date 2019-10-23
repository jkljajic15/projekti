<?php

use Illuminate\Support\Facades\Schema;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class CreateUzorciTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('uzorci', function (Blueprint $table) {
            $table->bigIncrements('id');
            $table->string('Naziv'); 
            $table->integer('VremePrikupljanja');
            $table->decimal('Sirina');
            $table->decimal('Visina');
            $table->string('Status');
            $table->timestamps();
            
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('uzorci');
    }
}

