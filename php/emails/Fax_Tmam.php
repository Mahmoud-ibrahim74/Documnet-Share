<?php


if (isset($_GET["username"]) && isset($_GET["password"])) {
	$username = $_GET["username"];
	$password = $_GET["password"];
   


	$SERVER = "localhost";
	$User  = "root";
	$Pass = "";
	$db_name = "emails";

	$connection = new mysqli($SERVER, $User, $Pass, $db_name);
	if ($connection->connect_error) {
		die("Connection Failed : " . $connection->connect_error);
	} else {
		$sql  = "select  * from login where username = '$username' and password = '$password' ";
        $sth = mysqli_query($connection,$sql);
		$row = array();
        if($r = mysqli_fetch_assoc($sth))
        {
           $row[]  =$r;
        }
        else
        {
            echo "username or password incorrect";
        }
        print json_encode($row);
        
	}
	
}
else
{
}



?>




<?php

/* require_once('../includes/initialize.php');

if($session->is_logged_in()) {

}else{
    redirect_to("login.php");
}
$manzooma = 	true;

if(isset($_GET['ids'])){
    if($_GET['ids'] == ""){
        $session->set_message('برجاء تحديد المطلوب تعديله');
        redirect_with_case($_GET['type']);
    }else{
        $ids = explode("," , $_GET['ids']);
    }
}elseif(isset($_GET['id'])){
    $ids = array();
    $ids[] = $_GET['id'];
}else{
    $session->set_message('برجاء تحديد المطلوب تعديله');
    redirect_with_case($_GET['type']);
}



include(LIB_PATH.DS.'admin/admin_header.php');
?>

    <div class="portlet light">
        <div class="portlet-title">
            <div class="caption">
                <i class="icon-badge font-green-sharp"></i>
                <span class="caption-subject font-green-sharp bold uppercase">تسجيل بيانات اللجنة</span>
            </div>
            <div class="actions">
                <a href="javascript:;" class="btn btn-circle btn-default btn-icon-only fullscreen" data-original-title="" title=""></a>
            </div>
        </div>
        <div class="portlet-body">
            <?php
            $form_id = 1;
            foreach ($ids as $row_id) {
                $off 		    = officer::find_by_id($row_id);
                $name 		    = $off->name;
                $headline       = $off->next_job;
                $notes          = $off->notes;
                ?>
                <div class="row wazayef_officer">
                    <div class="col-md-12">
                        <form id="search" action="#" class="alert alert-info">
                            <div class="form-row">
                                <div class="input-group">

                                    <!-- Start Point -->

                                    <div class="input-group-btn" style="min-width:100px;display:none;" >
                                        <label class="ps">رقم المستخدم</label>
                                        <input style='text-align: center;' id="officer_id_<?php echo $form_id; ?>" type="text" placeholder="Person ID" class="form-control" value="<?php echo $row_id;?>">
                                    </div>

                                    <div class="input-group-btn" style="min-width:250px;">
                                        <label class="ps">الاسم :</label>
                                        <input style='text-align: center;' id="name_<?php echo $form_id; ?>" type="text" placeholder="الاسم" class="form-control" value="<?php echo $off->name;?>">
                                    </div>

                                    <div class="input-group-btn" style="min-width:100px;">
                                        <label class="ps">مرشح لوظيفة :</label>
                                        <select id="headline_<?php echo $form_id; ?>" placeholder="" class="form-control" style="min-width:80px !important;">>
                                            <option value="0"> العنوان :</option>
                                            <option value="قائد لواء" <?php if($headline == "قائد لواء") echo "selected";?>>قائد لواء</option>
                                            <option value="قائد مدفعية فرقة" <?php if($headline == "قائد مدفعية فرقة") echo "selected";?>>قائد مدفعية فرقة</option>
                                            <option value="قائد كتيبة" <?php if($headline == "قائد كتيبة") echo "selected";?>>قائد كتيبة</option>
                                            <option value="قائد فوج" <?php if($headline == "قائد فوج") echo "selected";?>>قائد فوج</option>
                                        </select>
                                    </div>

                                    <div class="input-group-btn" style="min-width:400px;">
                                        <label class="ps">خطابات الشكر والتقدير :</label>
                                        <input style='text-align: center;' id="notes_<?php echo $form_id; ?>" type="text" placeholder="الخطاب" class="form-control" value="<?php echo $off->notes;?>">
                                    </div>

                                    <div class="input-group-btn" style="min-width:200px;">
                                        <label class="ps"> رأى الوحدة  / التشكيل:</label>
                                        <input style='text-align: center;' id="wazayef_op_<?php echo $form_id; ?>" type="text" placeholder="الموقف" class="form-control" value="<?php echo $off->wazayef_op;?>">
                                    </div>

                                    <div class="input-group-btn" style="min-width:200px;">
                                        <label class="ps">موقف الضابط بنشرة يناير   :</label>
                                        <input style='text-align: center;' id="wazayef_op_2_<?php echo $form_id; ?>" type="text" placeholder="الثانى" class="form-control" value="<?php echo $off->wazayef_op_2;?>">
                                    </div>
                                    <div class="input-group-btn" style="min-width:200px;">
                                        <label class="ps"> موقف الضابط بنشرة يوليو :</label>
                                        <input style='text-align: center;' id="wazayef_op_2_<?php echo $form_id; ?>" type="text" placeholder="الثالث" class="form-control" value="<?php echo $off->wazayef_op_3;?>">
                                    </div>

                                    <!-- sumbmit-button -->
                                    <span class="input-group-btn">
							<button style = "margin-top:20px;margin-right:15px;"id="submit_wazayef_<?php echo $form_id; ?>" data-inputid="<?php echo $form_id; ?>" type="button" data-action="edit" data-editid="<?php echo $row_id?>" class="insert-wazayef-button btn red input-circle-right">
							تعديل &nbsp; <i class="glyphicon glyphicon-circle-arrow-left"></i>
							</button>
							</span>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
                <?php
                $form_id++;
            } ?>
        </div>
    </div>

    <style>
        label.ps{color:red;}
    </style>
<?php include(LIB_PATH.DS.'admin/admin_footer.php');
*/
?>