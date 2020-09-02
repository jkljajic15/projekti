<?php


class ListingUnos
{
    private $url;
    private $megabajti;

    /**
     * ListingUnos constructor.
     * @param string $url
     * @param int $megabajti
     */
    public function __construct(string $url, int $megabajti)
    {
        $this->url = $url;
        $this->megabajti = $megabajti;
    }


    public function dodajMegabajte(int $megabajti){
        $this->megabajti += $megabajti;
    }

    /**
     * @return string
     */
    public function getUrl(): string
    {
        return $this->url;
    }

    /**
     * @return int
     */
    public function getMegabajti(): int
    {
        return $this->megabajti;
    }
}