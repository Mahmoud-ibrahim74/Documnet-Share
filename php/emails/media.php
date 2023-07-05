<?php

if (isset($_GET["filename"])) {
	$filename = $_GET["filename"];


    $source = dirname(__FILE__) ."\media\\". $filename;
      if(!file_exists($source))
      {
        die("File not Found !"); 
      }
      else
      {
        $mm_type = "application/octet-stream";
        header("Pragma: public");
        header("Expires: 0");
        header("Cache-Control: must-revalidate,post-check=0,pre-check=0");
        header("Cache-Control: public");      
        header("Content-Description: File Transfer");
        header("Content-Type: ".$mm_type);
        header("Content-Length: ".(string)(filesize($source)));
        header("Content-Disposition: attachment;filename=$source");
        header("Content-Transfer-Encoding: binary");
        readfile($source);
      }

		// $zip_name = "files.zip";
		// $zip = new ZipArchive;
		// $zip->open($zip_name,ZipArchive::OVERWRITE);
		// foreach($rowFileNames as $Arrfile_name)
		// {
		// 	$dest = dirname(__FILE__) ."\media\\" . $Arrfile_name;
		// 	if(file_exists($dest))
		// 	{
		// 		$zip->addFile($dest,);
		// 	}
		// }
		// $zip->close();
		// header('Content-Type: application/zip');
		// header('Content-Disposition: attachment; filename="'.basename($zip_name).'"');
		// header('Content-Length: '.filesize($dest));
		// readfile($dest);



		

			
       
        
	}
?>

