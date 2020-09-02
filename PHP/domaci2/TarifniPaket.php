<?php


class TarifniPaket
{
    private $imePaketa;
    private $maksimalnaBrzina;
    private $cenaPaketa;
    private $neogranicenSaobracaj;
    private $megabajti;
    private $cenaPoMegabaju;

    /**
     * TarifniPaket constructor.
     * @param string $imePaketa
     * @param int $maksimalnaBrzina
     * @param float $cenaPaketa
     * @param bool $neogranicenSaobracaj
     * @param int $megabajti
     * @param float $cenaPoMegabaju
     */
    public function __construct(string $imePaketa,int $maksimalnaBrzina, float $cenaPaketa, bool $neogranicenSaobracaj, int $megabajti, float $cenaPoMegabaju)
    {
        $this->imePaketa = $imePaketa;
        $this->maksimalnaBrzina = $maksimalnaBrzina;
        $this->cenaPaketa = $cenaPaketa;
        $this->neogranicenSaobracaj = $neogranicenSaobracaj;
        $this->megabajti = $megabajti;
        $this->cenaPoMegabaju = $cenaPoMegabaju;
    }

    /**
     * @return float
     */
    public function getCenaPoMegabaju(): float
    {
        return $this->cenaPoMegabaju;
    }

    /**
     * @return string
     */
    public function getImePaketa(): string
    {
        return $this->imePaketa;
    }

    /**
     * @return float
     */
    public function getCenaPaketa(): float
    {
        return $this->cenaPaketa;
    }

    /**
     * @return bool
     */
    public function isNeogranicenSaobracaj(): bool
    {
        return $this->neogranicenSaobracaj;
    }

    /**
     * @return int
     */
    public function getMegabajti(): int
    {
        return $this->megabajti;
    }
}