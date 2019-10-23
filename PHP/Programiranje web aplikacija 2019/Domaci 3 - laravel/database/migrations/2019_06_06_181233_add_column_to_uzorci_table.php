<?php

use Illuminate\Support\Facades\Schema;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class AddColumnToUzorciTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::table('uzorci', function (Blueprint $table) {
            $table->string('Laboratorija')->default('null');
            $table->string('Ishod')->default('null');
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::table('uzorci', function (Blueprint $table) {
            $table->dropColumn('Laboratorija');
            $table->dropColumn('Ishod');
        });
    }
}
